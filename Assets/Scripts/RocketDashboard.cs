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

    //TODO: �ʱ�Y�� ���������� ��ġ �����ϰ� ����Y������ ������ġ�� �������� �������
    private float startingY;

    private void Awake()
    {
        // ������ ���� Y ��ġ ����
        startingY = transform.position.y;
        // �ְ� ���� �ҷ�����
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
