using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public QuestManager questManager;

    // 게임 버튼들
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    

    private int standClicks = 0;

    // 플레이어와 딜러 스크립트에 접근
    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    

    // 접근하고 업데이트하기 위한 public text
    public Text scoreText;
    public Text dealerScoreText;
    public Text standBtnText;
    public Text winnerText;
    

    // 딜러의 2번째 카드 가리는거
    public GameObject hideCard;


    //퀘스트 관련
    public int hitCount = 0; //히트 버튼 클릭 횟수
    internal int winCount = 0; //승리 횟수
    public int winningStreak = 0; //연속 승리 횟수
    void Start()
    {
        if(questManager == null)
        {
            questManager = FindObjectOfType<QuestManager>();
            if(questManager != null)
            {
                Debug.Log("Quest.. 자동 연결 성공!");
            }
            else
            {
                Debug.Log("못찾았어요.. 하..");
            }
        }
        // 버튼 클릭 리스너 추가
        dealBtn.gameObject.SetActive(true);
        hitBtn.gameObject.SetActive(false);
        standBtn.gameObject.SetActive(false);
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());

    }

    private void DealClicked()
    {

        // 게임 시작할때 수중의 값 초기화 해주기
        playerScript.ResetHand();
        dealerScript.ResetHand();
        // 딜러 수중의 값 시작시에 숨기기
        winnerText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle(); //카드 순서 섞기
        playerScript.StartHand();
        dealerScript.StartHand();
        // 수중의 스코어 업데이트
        scoreText.text = "수중의 값: "+playerScript.handValue;
        dealerScoreText.text = "수중의 값: " + dealerScript.handValue;
        // 딜러 카드들 중 하나 감추기
        hideCard.GetComponent<Renderer>().enabled = true;
        // 버튼 가시성 조정
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "스탠드";
    }

    private void HitClicked()
    {
        // 테이블 위에 아직 공간이 남아있는지 체크
        if(playerScript.cardIndex < 10)
        {
            playerScript.GetCard();
            scoreText.text = "수중의 값: " + playerScript.handValue.ToString();
            hitCount++;
            if(playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "콜";
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 17 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "수중의 값: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }

    // 승자 패자 체크
    void RoundOver()
    {
        // 버스트인지인 21인지
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;

        // 스탠드 버튼이 두번보다 덜 클릭되었고 21이 아니거나 버스트도아닌데 게임을 끝냈을 떄
        if (standClicks < 2 && !playerBust && dealerBust && !player21 && dealer21) return;
        bool roundOver = true;
        // 둘다 버스트(22이상일때)
        if(playerBust && dealerBust)
        {
            winnerText.text = "버스트";
            winningStreak = 0;
        }

        // 플레이어가 버스트인데 딜러는 아니거나, 딜러가 플레이어보다 수중에 가진 값이 높을 때
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            winnerText.text = "딜러 *승*";
            winningStreak = 0;
        }
        // 딜러가 버스트인데 플레이어는 아니거나, 플레이어가 딜러보다 수중에 가진 값이 높을 때
        else if(dealerBust || (!playerBust && playerScript.handValue > dealerScript.handValue))
        {
            winnerText.text = "플레이어 *승*";
            winCount++;
            winningStreak++;
        }
        // 비기는거
        else if (playerScript.handValue == dealerScript.handValue)
        {
            winnerText.text = "비겼습니다";
            winningStreak = 0;
        }
        else
        {
            roundOver = false;
        }
        // 
        if(roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            winnerText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            standClicks = 0;
            
            if (questManager != null)
            {
                questManager.EvaluateAndToast();
            }
            else
            {
                Debug.LogError("QuestManager가 GameManager에 연결되지 않았습니다!");
            }
            hitCount = 0;
            

        }
    }
}
