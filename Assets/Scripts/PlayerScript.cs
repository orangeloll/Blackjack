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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
