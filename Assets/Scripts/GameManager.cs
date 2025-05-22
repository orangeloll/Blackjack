using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public QuestManager questManager;

    // ���� ��ư��
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    

    private int standClicks = 0;

    // �÷��̾�� ���� ��ũ��Ʈ�� ����
    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    

    // �����ϰ� ������Ʈ�ϱ� ���� public text
    public Text scoreText;
    public Text dealerScoreText;
    public Text standBtnText;
    public Text winnerText;
    

    // ������ 2��° ī�� �����°�
    public GameObject hideCard;
    internal int winCount;

    void Start()
    {
        if(questManager == null)
        {
            questManager = FindObjectOfType<QuestManager>();
            if(questManager != null)
            {
                Debug.Log("Quest.. �ڵ� ���� ����!");
            }
            else
            {
                Debug.Log("��ã�Ҿ��.. ��..");
            }
        }
        // ��ư Ŭ�� ������ �߰�
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());

    }

    private void DealClicked()
    {

        // ���� �����Ҷ� ������ �� �ʱ�ȭ ���ֱ�
        playerScript.ResetHand();
        dealerScript.ResetHand();
        // ���� ������ �� ���۽ÿ� �����
        winnerText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle(); //ī�� ���� ����
        playerScript.StartHand();
        dealerScript.StartHand();
        // ������ ���ھ� ������Ʈ
        scoreText.text = "������ ��: "+playerScript.handValue;
        dealerScoreText.text = "������ ��: " + dealerScript.handValue;
        // ���� ī��� �� �ϳ� ���߱�
        hideCard.GetComponent<Renderer>().enabled = true;
        // ��ư ���ü� ����
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "���ĵ�";
    }

    private void HitClicked()
    {
        // ���̺� ���� ���� ������ �����ִ��� üũ
        if(playerScript.cardIndex < 10)
        {
            playerScript.GetCard();
            scoreText.text = "������ ��: " + playerScript.handValue.ToString();
            if(playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "������ ��: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }

    // ���� ���� üũ
    void RoundOver()
    {
        // ����Ʈ������ 21����
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;

        // ���ĵ� ��ư�� �ι����� �� Ŭ���Ǿ��� 21�� �ƴϰų� ����Ʈ���ƴѵ� ������ ������ ��
        if (standClicks < 2 && !playerBust && dealerBust && !player21 && dealer21) return;
        bool roundOver = true;
        // �Ѵ� ����Ʈ(22�̻��϶�)
        if(playerBust && dealerBust)
        {
            winnerText.text = "����Ʈ";
        }

        // �÷��̾ ����Ʈ�ε� ������ �ƴϰų�, ������ �÷��̾�� ���߿� ���� ���� ���� ��
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            winnerText.text = "���� *��*";
        }
        // ������ ����Ʈ�ε� �÷��̾�� �ƴϰų�, �÷��̾ �������� ���߿� ���� ���� ���� ��
        else if(dealerBust || (!playerBust && playerScript.handValue > dealerScript.handValue))
        {
            winnerText.text = "�÷��̾� *��*";
            winCount++;
        }
        // ���°�
        else if (playerScript.handValue == dealerScript.handValue)
        {
            winnerText.text = "�����ϴ�";
        }
        else
        {
            roundOver = false;
        }
        // 
        if(roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            winnerText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            standClicks = 0;
            if (questManager != null)
            {
                questManager.EvaluateAndToast();
            }
            else
            {
                Debug.LogError("QuestManager�� GameManager�� ������� �ʾҽ��ϴ�!");
            }

        }
    }
}
