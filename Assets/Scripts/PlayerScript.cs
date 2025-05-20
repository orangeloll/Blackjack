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

    public GameObject[] hand;

    public int cardIndex = 0;

    List<CardScript> aceList = new List<CardScript>();
    private void LateUpdate()
    {

    }

    public void StartHand()
    {
        GetCard(); // 처음에 카드 2개뽑으니까 GetCard 두번 호출
        GetCard();
    }

    //플레이어 또는 딜러의 손에 카드 추가
    public int GetCard()
    {
        // 테이블 위에 있는 카드들에 스프라이트와 값을 할당하기 위해 Deal Card를 사용합니다.
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        // 화면에 카드를 보여줍니다.
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // 카드 값 더하기
        handValue += cardValue;
        // 카드가 1값이면 에이스 카드다
        if(cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        // 1대신 11을 사용할 수 있는지 체크하기
        //AceCheck();
        cardIndex++;
        return handValue;
    }
}
