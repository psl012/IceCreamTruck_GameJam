using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public enum GameState{Play, TimeOut};

    public GameState _gameState;

    [SerializeField] float _timer;
    public float elapsed {get; private set;} 

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
        
        elapsed = _timer;        
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

        if(elapsed <= 0)
        {
            elapsed = 0;
            _gameState = GameState.TimeOut;
        }

        elapsed -= Time.deltaTime;
    }
}
