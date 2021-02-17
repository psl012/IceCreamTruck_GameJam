using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    const string BASE_TXT = "Score: ";

    public static ScoreManager instance;
    TextMeshProUGUI _textMeshPro;
    
    void Awake()
    {
        instance = this;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.instance.onRestartLevel += RestartScore;
    }

    public void UpdateScore(float score)
    {
        _textMeshPro.text = BASE_TXT + score.ToString();
    }

    void RestartScore()
    {
        _textMeshPro.text = BASE_TXT + "0";
    }
}
