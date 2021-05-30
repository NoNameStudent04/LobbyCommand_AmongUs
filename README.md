# LobbyCommand for AmongUs Impostor server
어몽어스 사설서버를 위한 LobbyCommand 번역본입니다. 현재는 커맨드만 번역이 되어있으며 알수없는 명령어(Unknown command)는 원본이 그대로 남아있는 상태입니다.

# How to use
```diff
✅ "main" branche에서 추출된 파일을 받거나, "source"에서 소스코드를 받아 직접 빌드후 사용할 수 있습니다.
❗❗ 플러그인 적용 경로 : Impostor Server가 있는 폴더 → plugins
❗❗ (빌드 전용) 플러그인 빌드 경로 : Ctrl+B를 통해 빌드 후에 파일명을 제외한 이전 폴더까지 복사후 이동이 가능합니다.
```
**빌드를 위한 가이드 (빌드 방법을 알시 스킵가능)**
```diff
1) 해당 레포지토리를 내려받습니다. (git clone 또는 zip으로)
2) (압축파일 형태일시) 압축을 해제하고, 폴더를 들어갑니다. (기본값은 "LobbyCommand_AmongUs-master" 일것입니다)
3) 폴더 내로 들어왔으면 두개의 폴더중 "LobbyCommands" 폴더를 클릭후 "GameEventListenr.cs" 파일을 엽니다. (상관은 없으나 폴더로 여는것을 권장)
4) 소스코드 로딩이 완료되었을시 Ctrl+B를 눌러 빌드를 하고 적용합니다.
```

# Commands
| Command | Description | Accepted Values | Example Usage |
| --- | --- | --- | --- |
| `/임포설정 (숫자)` | 임포스터를 몇명으로 할것인지 설정합니다. | `1`, `2` or `3` | `/임포설정 3` |
| `/맵변경 (맵이름)` | 맵 변경을 합니다. | `Skeld`, `MiraHQ` or `Polus` or 'Airship' | `/맵변경 airship` |
| --- | 맵변경시 대소문자 구분 없이 변경이 가능합니다. | --- | --- |

# License
* [GNU General Public License v3.0](https://www.gnu.org/licenses/gpl-3.0.html)
* [English version(Original)](https://github.com/oliver4888/Impostor-LobbyCommands)
