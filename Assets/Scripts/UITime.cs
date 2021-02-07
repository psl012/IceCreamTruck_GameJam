using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITime : MonoBehaviour
{
    const string TIMER_TXT = "Time Left: ";
    TextMeshProUGUI _textMeshPro;

    void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.instance._gameState == LevelManager.GameState.Play)
        {
            _textMeshPro.text =TIMER_TXT + LevelManager.instance.elapsed.ToString("#.");
        }
        else if(LevelManager.instance._gameState == LevelManager.GameState.TimeOut)
        {
            _textMeshPro.text = "Time Out";
        }
    }
}
