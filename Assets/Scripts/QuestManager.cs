using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 꼭 있어야 함

public class QuestManager : MonoBehaviour
{
    public PlayerScript player;
    public Text resultText;       // <- UI 연결
    public GameObject questPanel; // <- QuestPanel 연결

    private List<Quest> quests = new List<Quest>();

    void Start()
    {
        quests.Add(new Quest
        {
            title = "정확히 21점!",
            description = "21점을 정확히 달성하세요.",
            condition = (p) => p.handValue == 21
        });

        quests.Add(new Quest
        {
            title = "Hit 3번 이상하고 승리!",
            description = "3회 이상 Hit하고 이기기",
            condition = (p) => p.hitCount >= 3 && !p.isBust
        });

        questPanel.SetActive(false); // 처음엔 닫힘 상태
    }

    public void EvaluateQuests()
    {
        string result = "";
        foreach (var quest in quests)
        {
            quest.Check(player);
            if (quest.isCompleted)
                result += $"✅ {quest.title}\n";
            else
                result += $"❌ {quest.title}\n";
        }

        resultText.text = result;
        questPanel.SetActive(true); // 퀘스트 창 열기
    }

    public void CloseQuestPanel()
    {
        questPanel.SetActive(false);
    }
}
