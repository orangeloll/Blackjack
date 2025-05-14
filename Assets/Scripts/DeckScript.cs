using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardValues = new int[53];
    int currentIndex = 0;
    void Start()
    {
        
    }

    
    void GetCardValues()
    {
        int num = 0;
        // 카드에 값 할당하는 반복문
        for(int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            // 카드 개수 카운트, 52
            num %= 13;
            // 값이 13으로 나눠지고 남은 나머지 값

            // num 값이 10을 넘으면 그 값에 10 값을 할당해줌 -> J, Q, K는 10의 값을 가지지 11, 12, 13의 값을 가지지 않음
            if(num > 10 || num == 0)
            {
                num = 10;
            }
            cardValues[i] = num++;
        }
        currentIndex = 1;
    }
    public void Shuffle()
    {
        //  배열 섞기
        for(int i = cardSprites.Length -1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);//Fisher-Yates 방식
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        } 
    }

    public int DealCard(CardScript cardScript)
    {
        cardScript.SetSprite(cardSprites[currentIndex]);
        cardScript.SetValue(cardValues[currentIndex]);
        currentIndex++;
        return cardScript.GetValueOfCard();
    }

    public Sprite GetCardBack()
    {
        return cardSprites[0];
    }
}
