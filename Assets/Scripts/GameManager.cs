﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : SingletonBehaviour<GameManager>
{
    public int ScoreIncreaseAmount = 1;
    public ScoreText ScoreText; // 점수를 출력할 UI 텍스트
    public GameObject GameOverUI; // 게임 오버시 활성화 할 UI 게임 오브젝트

    private int _score = 0; // 게임 점수
    private bool _isEnd = false; // 게임 오버 상태

    void Update()
    {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if (_isEnd && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore()
    {
        _score += ScoreIncreaseAmount;
        ScoreText.UpdateText(_score);
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void End()
    {
        GameOverUI.SetActive(true);
    }
}