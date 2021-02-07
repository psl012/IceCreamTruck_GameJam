using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    const string BASE_TXT = "Score: ";

    public static ScoreManager instance;
    TextMeshProUGUI _textMeshPro;
    
    float score = 0;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.instance.onRestartLevel += RestartScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(float point)
    {
        score += point;
        _textMeshPro.text = BASE_TXT + score.ToString();
    }

    void RestartScore()
    {
        score = 0;
        _textMeshPro.text = BASE_TXT + score.ToString();
    }
}
