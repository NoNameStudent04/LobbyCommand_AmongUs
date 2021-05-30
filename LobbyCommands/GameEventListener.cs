using System;
using System.Linq;
using System.Threading.Tasks;

using Impostor.Api.Events;
using Impostor.Api.Innersloth;
using Impostor.Api.Events.Player;

using Microsoft.Extensions.Logging;

namespace LobbyCommands
{
    public class GameEventListener : IEventListener
    {
        readonly ILogger<LobbyCommandsPlugin> _logger;
        readonly string[] _mapNames = Enum.GetNames(typeof(MapTypes));

        public GameEventListener(ILogger<LobbyCommandsPlugin> logger) => _logger = logger;

        [EventListener]
        public void OnPlayerChat(IPlayerChatEvent e)
        {
            if (e.Game.GameState != GameStates.NotStarted || !e.Message.StartsWith("/") || !e.ClientPlayer.IsHost)
                return;

            Task.Run(async () => await DoCommands(e));
        }

        private async Task DoCommands(IPlayerChatEvent e)
        {
            _logger.LogDebug($"Attempting to evaluate command from {e.PlayerControl.PlayerInfo.PlayerName} on {e.Game.Code.Code}. Message was: {e.Message}");

            string[] parts = e.Message.ToLowerInvariant()[1..].Split(" ");

            switch (parts[0])
            {
                case "도움":
                    if (parts.Length == 1)
                    {
                        await e.PlayerControl.SendChatAsync($"다음 맵중에서 선택해주세요: {string.Join(", ", _mapNames)}");
                        return;
                    }
                case "임포설정":
                    if (parts.Length == 1)
                    {
                        await e.PlayerControl.SendChatAsync($"올바른 임포스터 설정을 위해 숫자만 넣어주세요.\n[Example. /임포설정 2]");
                        return;
                    }

                    if (int.TryParse(parts[1], out int num))
                    {
                        num = Math.Clamp(num, 1, 3);

                        await e.PlayerControl.SendChatAsync($"임포스터가 [{num}명]으로 설정되었습니다.");

                        e.Game.Options.NumImpostors = num;
                        await e.Game.SyncSettingsAsync();
                    }
                    else
                        await e.PlayerControl.SendChatAsync($"'{parts[1]}'는 숫자가 아닙니다. 올바른 값을 입력해주세요.");
                    break;
                case "맵변경":
                    if (parts.Length == 1)
                    {
                        await e.PlayerControl.SendChatAsync($"다음 맵중에서 선택해주세요: {string.Join(", ", _mapNames)}");
                        return;
                    }

                    if (!_mapNames.Any(name => name.ToLowerInvariant() == parts[1]))
                    {
                        await e.PlayerControl.SendChatAsync($"올바르지 않은 맵입니다. 다음 맵중에서 선택해주세요: {string.Join(", ", _mapNames)}");
                        return;
                    }

                    MapTypes map = Enum.Parse<MapTypes>(parts[1], true);

                    await e.PlayerControl.SendChatAsync($"{map}으로 설정하였습니다.");

                    e.Game.Options.Map = map;
                    await e.Game.SyncSettingsAsync();
                    break;
                default:
                    _logger.LogInformation($"Unknown command {parts[0]} from {e.PlayerControl.PlayerInfo.PlayerName} on {e.Game.Code.Code}.");
                    break;
            }
        }
    }
}
