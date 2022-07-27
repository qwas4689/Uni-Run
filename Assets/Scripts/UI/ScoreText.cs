using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// OnScoreChanged 에 종속되어 OnScoreChanged 를 참조
public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _ui;



    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        
    }

    void OnEnable()
    {
        // 혹시나 다른곳에서 AddLisrener()가 될 수 있으므로 구독해제를 해 준다.
        GameManager.Instance.OnScoreChanged.RemoveListener(UpdateText);
        // 이벤트 구독
        GameManager.Instance.OnScoreChanged.AddListener(UpdateText);

        // C# 에서의 이벤트 구독해제
        // GameManager.Instance.OnScoreChanged2 -= UpdateText;
        // C# 에서의 이벤트 구독
        // GameManager.Instance.OnScoreChanged2 += UpdateText; 
    }

    public void UpdateText(int score)
    {
        // _ui의 텍스트 수정
        _ui.text = $"Score : {score}";
                
    }

    void OnDisable()
    {
        // 비 활성화 되면 이벤트 통지를 받을 필요가 없으므로 구독해제를 한것
        GameManager.Instance.OnScoreChanged.RemoveListener(UpdateText);

        // C#에서의 구독 해제
        // GameManager.Instance.OnScoreChanged2 -= UpdateText;
    }
}
