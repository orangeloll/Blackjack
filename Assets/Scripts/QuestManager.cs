using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 꼭 있어야 함

public class QuestManager : MonoBehaviour
{
    
    public PlayerScript player;
    public Text resultText;       // <- UI 연결
    public GameObject questPanel; // <- QuestPanel 연결
    public GameManager gameManager;
    private List<Quest> quests = new List<Quest>();
    public ToastManager toastManager;
    
void Start()
    {
        quests.Add(new Quest
        {
            title = "첫 승리!",
            description = "처음으로 게임에서 이기기",
            condition = (p) => gameManager.winCount == 1
        });
        quests.Add(new Quest
        {
            title = "정확히 21점!",
            description = "21점을 정확히 달성하세요.",
            condition = (p) => p.handValue == 21
        });

        quests.Add(new Quest
        {
            title = "히트 3번 이상하고 승리!",
            description = "3회 이상 히트하고 이기기",
            condition = (p) => gameManager.hitCount >= 3 && !p.isBust
        });

        quests.Add(new Quest
        {
            title = "3번 연속 승리!",
            description = "3번 연속 승리 시",
            condition = (p) => gameManager.winningStreak == 3
        });
        quests.Add(new Quest
        {
            title = "동점!",
            description = "게임에서 비기기",
            condition = (p) => gameManager.winnerText.text =="비겼습니다"
        });
        quests.Add(new Quest
        {
            title = "버스트!",
            description = "플레이어와 딜러 모두 버스트일 시",
            condition = (p) => gameManager.winnerText.text == "버스트"
        });
        quests.Add(new Quest
        {
            title = "노 히트!",
            description = "히트 클릭 없이 승리",
            condition = (p) => gameManager.hitCount == 0 && gameManager.winnerText.text == "플레이어 *승*" && p.cardIndex == 2
        });
        quests.Add(new Quest
        {
            title = "블랙잭!",
            description = "처음 받은 카드 두장으로 21값 만들어서 승리하기",
            condition = (p) => gameManager.hitCount == 0 &&gameManager.winnerText.text == "플레이어 *승*" 
            &&p.cardIndex == 2&&p.handValue == 21
    });


        questPanel.SetActive(false); // 처음엔 닫힘 상태
    }


    public void EvaluateAndToast()
    {
        foreach (var quest in quests)
        {
            if (!quest.isCompleted && quest.condition(player))
            {
                quest.isCompleted = true;
                Debug.Log($"🎯 퀘스트 완료: {quest.title}");

                if (toastManager != null)
                {
                    toastManager.ShowToast($"🎯 퀘스트 완료: {quest.title}");
                }
                else
                {
                    Debug.LogError("❌ toastManager가 null임!");
                }
            }
        }
    }



    public void UpdateQuestPanelUI()
    {
        string result = "";
        foreach (var quest in quests)
        {
            quest.Check(player);
            if (quest.isCompleted)
                result += $"<color=red><b>[완료]</b></color> {quest.title}\n";
            else
                result += $"{quest.title}\n";
        }

        resultText.text = result;
    }


    public void OpenQuestPanel()
    {
        UpdateQuestPanelUI();
        questPanel.SetActive(true);
    }

    public void CloseQuestPanel()
    {
        questPanel.SetActive(false);
    }
}
