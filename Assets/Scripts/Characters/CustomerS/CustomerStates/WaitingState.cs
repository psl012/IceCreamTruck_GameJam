using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : IState
{
    Customer _customer;
    CustomerEvents _customerEvents;

    public WaitingState (Customer customer, CustomerEvents customerEvents)
    {
        _customer = customer;
        _customerEvents = customerEvents;
    }

    public void Tick(){}

    public void OnEnter()
    {
        _customer._buyCounter = 0;
        _customerEvents.ReWaiting();
    }

    public void OnExit(){}
}
