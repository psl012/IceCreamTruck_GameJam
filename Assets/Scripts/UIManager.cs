using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _restartNotice;

    public static UIManager instance;

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
    }
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.instance.onTimeOut += ActivateRestartNotice;
        LevelManager.instance.onRestartLevel += DeactivateRestartNotice;
        DeactivateRestartNotice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateRestartNotice()
    {
        _restartNotice.SetActive(true);
    }

    void DeactivateRestartNotice()
    {
        _restartNotice.SetActive(false);      
    }
}
