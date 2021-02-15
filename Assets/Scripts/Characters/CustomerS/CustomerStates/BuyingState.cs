using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingState : IState
{
    float _elapsed; 
    float _buyTime;

    bool _finishedBuying;

    Customer _customer;

    CustomerEvents _customerEvents;

    public BuyingState(float buyTime, Customer customer, CustomerEvents customerEvents)
    {
        _buyTime = buyTime;
        _customer = customer;
        _customerEvents = customerEvents;
    }

    public void Tick()
    {
        if (_customer._buyCounter < _buyTime)
        {
            _customer._buyCounter += Time.deltaTime;
            _customerEvents.Transacting();
        }
        else
        {
            _customer._finishedBuying = true;
        }
    }

    public void OnEnter()
    {
        _customer._buyCounter = 0;
    }

    public void OnExit()
    {

    }
}
