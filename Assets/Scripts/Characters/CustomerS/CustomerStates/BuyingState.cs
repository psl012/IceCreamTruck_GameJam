using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingState : IState
{
    float _elapsed; 
    float _buyTime;

    bool _finishedBuying;

    Customer _customer;

    public BuyingState(float buyTime, Customer customer)
    {
        _buyTime = buyTime;
        _customer = customer;
    }

    public void Tick()
    {
        if (_elapsed < _buyTime)
        {
            _elapsed += Time.deltaTime;
        }
        else
        {
            _customer.SetFinishedBuying(true);
        }
    }

    public void OnEnter()
    {
        _elapsed = 0;
        Debug.Log("Enter Buying");
    }

    public void OnExit()
    {

    }
}
