# 🃏 유니티를 사용한 블랙잭

Unity로 제작한 **블랙잭 카드 게임**입니다.  
단순한 카드 게임이지만, **퀘스트 시스템**과 **토스트 알림 UI**를 추가해 재미 요소를 강화했습니다.

---

## 🎮 게임 설명

- 기본 룰은 일반적인 **블랙잭**과 동일합니다.
- `딜` 버튼 클릭 → 게임 시작
- 플레이어와 딜러는 2장의 카드를 받습니다 (딜러는 한 장 가림)
- 플레이어는 `히트` 또는 `스탠드`를 선택할 수 있습니다
- `스탠드` 선택 시 `콜` 버튼이 등장하여 게임 종료를 확정합니다

---

## 🧩 주요 기능

| 기능 | 설명 |
|------|------|
| ✅ 퀘스트 시스템 | 다양한 조건을 만족하면 퀘스트가 자동으로 달성되며 토스트로 알림 표시 |
| 🖼️ 퀘스트 UI | 퀘스트 완료 여부를 UI 패널에서 한눈에 확인 가능 |
| 🔁 게임 반복 가능 | 딜 버튼으로 게임을 여러 번 반복해서 플레이 가능 |
| 🚫 버그 방지 | 카드 인덱스 초과, 중복 처리 등 기본적인 예외처리 적용 |
| 🧪 커스터마이징 가능 | 추후 아이템, 전략 기능 등 확장성 고려된 구조 |

---

## 📁 프로젝트 구조

```bash
📦 Unity-Blackjack-Quest
├── 📁 Assets                     # 모든 코드와 리소스가 들어있는 폴더
│   ├── 📁 Scripts                # C# 스크립트들 (GameManager, PlayerScript 등)
│   ├── CardScript.cs          # 카드의 값, 이미지 설정 및 초기화
│   ├── DeckScript.cs          # 카드 섞기 및 카드 분배
│   ├── GameManager.cs         # 게임의 전체 흐름 관리
│   ├── PlayerScript.cs        # 플레이어/딜러 핸들 관리
│   ├── Quest.cs               # 개별 퀘스트 정의 클래스
│   ├── QuestManager.cs        # 퀘스트 조건 평가 및 UI 업데이트
│   └── ToastManager.cs        # 퀘스트 완료 토스트 알림 처리
│   ├── 📁 Sprites                # 카드 이미지, UI 아이콘 등
│   ├── 📁 Prefabs                # UI 프리팹 (ToastPanel 등)
│   ├── 📁 Scenes                 # 게임 씬 (.unity)
│   └── ...
├── 📁 Packages                   # Unity 패키지 관련 설정
├── 📁 ProjectSettings            # Unity 프로젝트 세팅 정보
├── .gitignore                   # Git 무시 대상 파일 목록
├── README.md                    # 깃허브 프로젝트 설명 파일
└── UpgradeLog.htm               # 유니티 프로젝트 업그레이드 로그 (자동 생성됨)

```

---

## 🛠️사용 기술
- Unity 2021.3.8f1(LTS)
- Visual Studio 2022
- Window 11 Home
- C#

---
## 📸 게임화면
![21114061_진해령_블랙잭_시연영상 (1)](https://github.com/user-attachments/assets/941db64f-6486-45ef-99fe-38e897357232)

---
## 💡 향후 개선 방향

- 전략성 강화: 상대방 카드 제거, 특수 아이템 추가
- 퀘스트 UI 고도화 및 애니메이션 추가
- 사운드 효과 및 점수 랭킹 시스템 추가

--
## 📚 참고 문헌
1. kurtkaiser, Unity Blackjack Game Tutorial, GitHub Repository,
https://github.com/kurtkaiser/Unity-Blackjack-Game-Tutorial

2. 꿈꾸는느티나무, [Unity 2D UI] Panel, Text, Button 메뉴 기능 구현,
https://dreamzelkova.tistory.com/entry/Unity2DUIPanel-Text-Button-메뉴기능-구현

---
