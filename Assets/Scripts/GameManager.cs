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
    

    private int standClick = 0;

    // 플레이어와 딜러 스크립트에 접근
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    // 접근하고 업데이트하기 위한 public text
    public Text scoreText;
    public Text dealerScoreText;
    public Text standBtnText;

    // 딜러의 2번째 카드 가리는거
    public GameObject hideCard;

    void Start()
    {
        // 버튼 클릭 리스너 추가
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        // 딜러 수중의 값 시작시에 숨기기
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle(); //카드 순서 섞기
        playerScript.StartHand();
        dealerScript.StartHand();
        // 수중의 스코어 업데이트
        scoreText.text = "수중의 값: "+playerScript.handValue;
        dealerScoreText.text = "수중의 값: " + dealerScript.handValue;
        // 버튼 가시성 조정
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "스탠드";
    }

    private void HitClicked()
    {
        // 테이블 위에 아직 공간이 남아있는지 체크
        if(playerScript.GetCard() <= 10)
        {
            playerScript.GetCard();
        }
    }

    private void StandClicked()
    {
        standClick++;
        if (standClick > 1) Debug.Log("end function");
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            //딜러 점수
        }
    }
}
