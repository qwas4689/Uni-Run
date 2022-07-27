using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : SingletonBehaviour<GameManager>
{
    public int ScoreIncreaseAmount = 1;

    // C#의 이벤트 객체를 만들지 않아도 댐
    // public event UnityAction OnGameEnd2;
    // public event UnityAction<int> OnScoreChanged2;

    // 유니티 이벤트
    public UnityEvent OnGameEnd = new UnityEvent();
    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();

    // Score에 대한 프로퍼티
    public int CurrentScore
    {
        get
        {
            // 스코어 반환
            return _currentScore;
        }
        set
        {
            // value : 프로퍼티를 구현할 때 사용가능
            // Score 의 값이라고 보면 됨.
            _currentScore = value;
            OnScoreChanged.Invoke(_currentScore);

            // C#의 이벤트는 널체크를 한다.
            // 구독자가 있는지 확인(널체크)
            // OnScoreChanged2?.Invoke(_currentScore);
        }

    }

    private int _currentScore = 0; // 게임 점수
    private bool _isEnd = false; // 게임 오버 상태

    void Update()
    {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if (_isEnd && Input.GetKeyDown(KeyCode.R))
        {
            reset();
            SceneManager.LoadScene(0);
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore()
    {
        CurrentScore += ScoreIncreaseAmount;
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void End()
    {
        _isEnd = true;
        OnGameEnd.Invoke();
        // C#에서의 이벤트는 널체크를 해야 함
        // OnGameEnd2?.Invoke();
        
    }

    private void reset()
    {
        _currentScore = 0;
        _isEnd = false;
    }
}