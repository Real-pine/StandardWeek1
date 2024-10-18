using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rocket rocket;
    [SerializeField] private Button retryButton;

    private void Awake()
    {

        // ���� ���� �� ��ư ����
        retryButton.gameObject.SetActive(false);

        retryButton.onClick.AddListener(Retry);
        //�̺�Ʈ ����
        rocket.Oncrash.AddListener(GameOver);

    }

    private void GameOver()
    {
        retryButton.gameObject.SetActive(true);
    }

    private void Retry()
    {
        SceneManager.LoadScene("RocketLauncher");
        retryButton.gameObject.SetActive(false);
    }
}
