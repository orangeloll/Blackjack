using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 게임 버튼들
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;

    // 플레이어와 딜러 스크립트에 접근
    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    void Start()
    {
        // 버튼 클릭 리스너 추가
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle(); //카드 순서 섞기
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
