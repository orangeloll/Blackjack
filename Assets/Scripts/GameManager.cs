using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���� ��ư��
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;
    void Start()
    {
        // ��ư Ŭ�� ������ �߰�
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
