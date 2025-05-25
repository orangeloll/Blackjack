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

    public void StartHand()
    {
        GetCard(); // 처음에 카드 2개뽑으니까 GetCard 두번 호출
        GetCard();
    }

    //플레이어 또는 딜러의 손에 카드 추가
    public int GetCard()
    {

        if (cardIndex >= hand.Length)
        {
            Debug.LogError($" 카드 인덱스 초과: 현재 cardIndex={cardIndex}, hand.Length={hand.Length}");
            return handValue;
        }
        // 테이블 위에 있는 카드들에 스프라이트와 값을 할당하기 위해 Deal Card를 사용
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
        AceCheck();
        cardIndex++;
        return handValue;
    }
    // 에이스 값이 변화할 필요가 있는지 찾는 것, 1에서 11 또는 11에서 1
    public void AceCheck()
    {   // 모든 에이스를 체크
        foreach(CardScript ace in aceList)
        {
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                // 만약 21 안넘으면 에이스 카드 값을 11로 침
                ace.SetValue(11);
                handValue += 10;
            } else if (handValue > 21 && ace.GetValueOfCard() == 11)
            { //21 넘으면 에이스 카드 값을 1로 쳐서 버스트(22이상이 되는것)을 막음
                ace.SetValue(1);
                handValue -= 10;

            }
        }
    }

    // 모든 카드 감추고, 값들 초기화
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
