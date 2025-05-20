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
    private void LateUpdate()
    {

    }

    public void StartHand()
    {
        GetCard(); // ó���� ī�� 2�������ϱ� GetCard �ι� ȣ��
        GetCard();
    }

    //�÷��̾� �Ǵ� ������ �տ� ī�� �߰�
    public int GetCard()
    {
        // ���̺� ���� �ִ� ī��鿡 ��������Ʈ�� ���� �Ҵ��ϱ� ���� Deal Card�� ����մϴ�.
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
        //AceCheck();
        cardIndex++;
        return handValue;
    }
}
