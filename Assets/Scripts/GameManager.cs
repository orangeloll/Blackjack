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

    // �÷��̾�� ���� ��ũ��Ʈ�� ����
    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    void Start()
    {
        // ��ư Ŭ�� ������ �߰�
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle(); //ī�� ���� ����
        playerScript.StartHand();
        dealerScript.StartHand();
    }

    private void HitClicked()
    {
        throw new NotImplementedException();
    }

    private void StandClicked()
    {
        throw new NotImplementedException();
    }

    
}
