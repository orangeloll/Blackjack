using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // ������ �÷��̾� ��θ� ���� ��ũ��Ʈ��

    public CardScript cardScript;
    public DeckScript deckScript;

    // �÷��̾�/������ �տ� �ִ� ���� ����
    public int handValue = 0;
    public bool isBust => handValue > 21;

    public int hitCount = 0;
    public bool usedStand = false;

    public GameObject[] hand;

    public int cardIndex = 0;

    List<CardScript> aceList = new List<CardScript>();

    public void StartHand()
    {
        GetCard(); // ó���� ī�� 2�������ϱ� GetCard �ι� ȣ��
        GetCard();
    }

    //�÷��̾� �Ǵ� ������ �տ� ī�� �߰�
    public int GetCard()
    {

        if (cardIndex >= hand.Length)
        {
            Debug.LogError($" ī�� �ε��� �ʰ�: ���� cardIndex={cardIndex}, hand.Length={hand.Length}");
            return handValue;
        }
        // ���̺� ���� �ִ� ī��鿡 ��������Ʈ�� ���� �Ҵ��ϱ� ���� Deal Card�� ���
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        // ȭ�鿡 ī�带 �����ݴϴ�.
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // ī�� �� ���ϱ�
        handValue += cardValue;
        // ī�尡 1���̸� ���̽� ī���
        if(cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        // 1��� 11�� ����� �� �ִ��� üũ�ϱ�
        AceCheck();
        cardIndex++;
        return handValue;
    }
    // ���̽� ���� ��ȭ�� �ʿ䰡 �ִ��� ã�� ��, 1���� 11 �Ǵ� 11���� 1
    public void AceCheck()
    {   // ��� ���̽��� üũ
        foreach(CardScript ace in aceList)
        {
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                // ���� 21 �ȳ����� ���̽� ī�� ���� 11�� ħ
                ace.SetValue(11);
                handValue += 10;
            } else if (handValue > 21 && ace.GetValueOfCard() == 11)
            { //21 ������ ���̽� ī�� ���� 1�� �ļ� ����Ʈ(22�̻��� �Ǵ°�)�� ����
                ace.SetValue(1);
                handValue -= 10;

            }
        }
    }

    // ��� ī�� ���߰�, ���� �ʱ�ȭ
    public void ResetHand()
    {
        for(int i = 0; i< hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }

        cardIndex = 0;
        handValue = 0;
        aceList = new List<CardScript>();
    }
}
