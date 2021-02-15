using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float _buyCounter = 0;
    public float _buyTime {get; private set;} = 2f;
    public bool _finishedBuying {get; set;} = false;
    public bool _isDead {get; set;} = false;
    [SerializeField] float point;
    bool _canBuy = false;
    StateMachine _stateMachine;
    Spawner _spawner;
    CustomerEvents _customerEvents;

    void Awake()
    {
        _spawner = GetComponentInParent<Spawner>();
        _customerEvents = GetComponent<CustomerEvents>();

        var waitingState = new WaitingState(this, _customerEvents);
        var buyingState = new BuyingState(_buyTime, this, _customerEvents);
        var finishedState = new FinishedState(this, _customerEvents, _spawner, point);
        var deadState = new DeadState(this, _spawner);

        _stateMachine = new StateMachine();

        At(waitingState, buyingState, IsCustomerCanBuy());
        At(buyingState, waitingState, NotIsCustomerCanBuy());
        At(waitingState, deadState, IsDead());
        At(buyingState, deadState, IsDead());
        At(buyingState, finishedState, IsFinishedBuying());

        _stateMachine.SetState(waitingState);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        Func<bool> IsCustomerCanBuy() => () => _canBuy;
        Func<bool> NotIsCustomerCanBuy() => () => !_canBuy;
        Func<bool> IsFinishedBuying() => () => _finishedBuying;
        Func<bool> IsDead() => () => _isDead;
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            _canBuy = true;
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            _canBuy = false;
        }
    }
}
