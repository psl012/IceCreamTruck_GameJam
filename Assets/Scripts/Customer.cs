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
    public AudioClip[] _audioClip;
    Rigidbody _rigidBody;
    public float _buyTime = 2f;
    public float _elapsed {get; private set;} = 0;



    Spawner _spawner;

    bool hasSpawned = false;



    public AudioSource _audioSource{get; private set;}
    StateMachine _stateMachine;
    bool _canBuy = false;
    bool _finishedBuying = false;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _spawner = GetComponentInParent<Spawner>();

        var waitingState = new WaitingState();
        var buyingState = new BuyingState(_buyTime, this);
        var finishedState = new FinishedState(this);

        _stateMachine = new StateMachine();

        At(waitingState, buyingState, IsCustomerCanBuy());
        At(buyingState, waitingState, NotIsCustomerCanBuy());
        At(buyingState, finishedState, IsFinishedBuying());

        _stateMachine.SetState(waitingState);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        Func<bool> IsCustomerCanBuy() => () => _canBuy;
        Func<bool> NotIsCustomerCanBuy() => () => !_canBuy;
        Func<bool> IsFinishedBuying() => () => _finishedBuying;

    }

    // Start is called before the first frame update
    void Start()
    {
        onTransactionComplete += UpdateScore;
      //  onTransactionComplete += PlayKaching;
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();

    }

    public void SetFinishedBuying(bool value)
    {
        _finishedBuying = value;
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

    public void SpawnNext()
    {
        if (!hasSpawned)
        {
            hasSpawned = true;
            _spawner.StartCoroutine(_spawner.SpawnCustomer());
        }
    }

    public void CustomerDestroy(float delay)
    {
        Destroy(gameObject, delay);
    }

    void OnDestroy()
    {
        onTransactionComplete -= UpdateScore;
    }   
}
