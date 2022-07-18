using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _ui;

    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        
    }
    public void UpdateText(int score)
    {
        // _ui의 텍스트 수정
        _ui.text = $"Score : {score}";
                
    }


}
