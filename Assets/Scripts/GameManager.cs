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
    public Button betBtn;
    void Start()
    {
        // 버튼 클릭 리스너 추가
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        throw new NotImplementedException();
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
