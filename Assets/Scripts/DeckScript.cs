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
        // ī�忡 �� �Ҵ��ϴ� �ݺ���
        for(int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            // ī�� ���� ī��Ʈ, 52
            num %= 13;
            // ���� 13���� �������� ���� ������ ��

            // num ���� 10�� ������ �� ���� 10 ���� �Ҵ����� -> J, Q, K�� 10�� ���� ������ 11, 12, 13�� ���� ������ ����
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
        //  �迭 ����
        for(int i = cardSprites.Length -1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);//Fisher-Yates ���
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
