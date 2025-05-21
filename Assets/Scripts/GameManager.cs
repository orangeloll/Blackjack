using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���� ��ư��
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    

    private int standClick = 0;

    // �÷��̾�� ���� ��ũ��Ʈ�� ����
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    // �����ϰ� ������Ʈ�ϱ� ���� public text
    public Text scoreText;
    public Text dealerScoreText;
    public Text standBtnText;

    // ������ 2��° ī�� �����°�
    public GameObject hideCard;

    void Start()
    {
        // ��ư Ŭ�� ������ �߰�
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        // ���� ������ �� ���۽ÿ� �����
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle(); //ī�� ���� ����
        playerScript.StartHand();
        dealerScript.StartHand();
        // ������ ���ھ� ������Ʈ
        scoreText.text = "������ ��: "+playerScript.handValue;
        dealerScoreText.text = "������ ��: " + dealerScript.handValue;
        // ��ư ���ü� ����
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "���ĵ�";
    }

    private void HitClicked()
    {
        // ���̺� ���� ���� ������ �����ִ��� üũ
        if(playerScript.GetCard() <= 10)
        {
            playerScript.GetCard();
        }
    }

    private void StandClicked()
    {
        standClick++;
        if (standClick > 1) Debug.Log("end function");
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            //���� ����
        }
    }
}
