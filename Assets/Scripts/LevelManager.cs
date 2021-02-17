using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public enum GameState{Play, TimeOut};

    public event Action onTimeOut = delegate {};

    public event Action onRestartLevel = delegate {};

    public GameState _gameState;

    public float _playerScore{get; set;} = 0;

    [SerializeField] float _timer;
    public float _elapsed {get; private set;} 

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
        
        _elapsed = _timer;        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameState == GameState.TimeOut)
        {
            return;
        }

        if(_elapsed <= 0)
        {
            _elapsed = 0;
            _gameState = GameState.TimeOut;
            onTimeOut();
        }

        _elapsed -= Time.deltaTime;
    }

    public void AddScore(float point)
    {
        _playerScore += point;
        ScoreManager.instance.UpdateScore(_playerScore);
    }

    public void RestartLevel()
    {
        _elapsed = _timer;
        _gameState = GameState.Play;
        _playerScore = 0;
        onRestartLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void DestroyCustomer(GameObject g_obj, float delay)
    {
        Destroy(g_obj, delay);
    }
}
