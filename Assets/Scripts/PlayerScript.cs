using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // 딜러랑 플레이어 모두를 위한 스크립트임

    public CardScript cardScript;
    public DeckScript deckScript;

    // 플레이어/딜러의 손에 있는 값의 총합
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
