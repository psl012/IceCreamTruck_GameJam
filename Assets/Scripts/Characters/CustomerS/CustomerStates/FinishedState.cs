using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedState : IState
{
    Customer _customer;
    CustomerEvents _customerEvents;
    Spawner _spawner;

    float _point;
    public FinishedState(Customer customer, CustomerEvents customerEvents, Spawner spawner, float point)
    {
        _customer = customer;
        _customerEvents = customerEvents;
        _point = point;
        _spawner = spawner;
    }

    public void Tick()
    {

    }

    public void OnEnter()
    {
        _customerEvents.TransactionComplete();
        ScoreManager.instance.UpdateScore(_point);
        _spawner.StartCoroutine(_spawner.SpawnCustomer());
        LevelManager.instance.DestroyCustomer(_customer.gameObject, 2f);
    }

    public void OnExit()
    {

    }
}
