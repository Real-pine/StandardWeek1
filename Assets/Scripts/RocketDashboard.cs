using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketDashboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HightScoreTxt;

    private float currentScore = 0f;
    private float hightScore = 0f;

    //TODO: 초기Y값 기준점으로 위치 저장하고 현재Y값에서 시작위치를 뺀값으로 점수계산
    private float startingY;

    private void Awake()
    {
        // 로켓의 시작 Y 위치 저장
        startingY = transform.position.y;
        // 최고 점수 불러오기
        hightScore = PlayerPrefs.GetFloat("HighScore", 0f);
        UpdateScoreUI();
    }

    void Update()
    {
        currentScore = Mathf.Max(currentScore, transform.position.y - startingY);
        
        if(currentScore > hightScore)
        {
            hightScore = currentScore;
            PlayerPrefs.SetFloat("HightScore", hightScore);
        }
            UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        currentScoreTxt.text = $"{currentScore:F2} M";
        HightScoreTxt.text = $"{hightScore:F2} M";

    }
}
