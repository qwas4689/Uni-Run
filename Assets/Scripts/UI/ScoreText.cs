using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// OnScoreChanged �� ���ӵǾ� OnScoreChanged �� ����
public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _ui;



    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        
    }

    void OnEnable()
    {
        // Ȥ�ó� �ٸ������� AddLisrener()�� �� �� �����Ƿ� ���������� �� �ش�.
        GameManager.Instance.OnScoreChanged.RemoveListener(UpdateText);
        // �̺�Ʈ ����
        GameManager.Instance.OnScoreChanged.AddListener(UpdateText);

        // C# ������ �̺�Ʈ ��������
        // GameManager.Instance.OnScoreChanged2 -= UpdateText;
        // C# ������ �̺�Ʈ ����
        // GameManager.Instance.OnScoreChanged2 += UpdateText; 
    }

    public void UpdateText(int score)
    {
        // _ui�� �ؽ�Ʈ ����
        _ui.text = $"Score : {score}";
                
    }

    void OnDisable()
    {
        // �� Ȱ��ȭ �Ǹ� �̺�Ʈ ������ ���� �ʿ䰡 �����Ƿ� ���������� �Ѱ�
        GameManager.Instance.OnScoreChanged.RemoveListener(UpdateText);

        // C#������ ���� ����
        // GameManager.Instance.OnScoreChanged2 -= UpdateText;
    }
}
