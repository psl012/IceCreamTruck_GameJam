using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public event Action onBuying = delegate {};
    public event Action onReWaiting = delegate {};
    public event Action onTransactionComplete = delegate {};
    public event Action<float> onTransacting = delegate {};
    [SerializeField] float point;
    [SerializeField] AudioClip[] _audioClip;
    Rigidbody _rigidBody;
    public float _buyTime = 2f;
    public float _elapsed {get; private set;} = 0;
    bool _canBuy = false;
    bool _finishedBuying = false;
    AudioSource _audioSource;
    Spawner _spawner;

    bool hasSpawned = false;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _spawner = GetComponentInParent<Spawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        onTransactionComplete += UpdateScore;
        onTransactionComplete += PlayKaching;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance._gameState == LevelManager.GameState.TimeOut)
        {
            return;
        }

        if (_finishedBuying) {return;}

        if (!_canBuy){return;}
        _elapsed += Time.deltaTime;
        onTransacting(_elapsed/_buyTime);

        if (_elapsed >= _buyTime)
        {
            Debug.Log("transaction complete");
            _canBuy = false;
            _finishedBuying = true;
            onTransactionComplete();
            SpawnNext();
            Destroy(gameObject,2f);
        }
    }

    void UpdateScore()
    {
        ScoreManager.instance.UpdateScore(point);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player" && !_finishedBuying)
        {
            Debug.Log("Hello");
            _canBuy = true;
            onBuying();
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player" && !_finishedBuying)
        {
            Debug.Log("Bye");
            _canBuy = false;
            _elapsed = 0;
            onReWaiting();
        }
    }
    void OnCollisionEnter (Collision collision)
    {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;
    
        if (collisionForce < 400.0F)
        {
            Debug.Log("Alive" + collisionForce);
        }
        else 
        {
            if (!_finishedBuying)
            {   
                _rigidBody.constraints = RigidbodyConstraints.None;
                Debug.Log("Dead" + collisionForce);
                SpawnNext();
                Destroy(gameObject,2f);
            }
        }
    }

    void SpawnNext()
    {
        if (!hasSpawned)
        {
            hasSpawned = true;
            _spawner.StartCoroutine(_spawner.SpawnCustomer());
        }
    }

    void PlayKaching()
    {
        _audioSource.PlayOneShot(_audioClip[0]);
    }

    void OnDestroy()
    {
        onTransactionComplete -= UpdateScore;
    }   
}
