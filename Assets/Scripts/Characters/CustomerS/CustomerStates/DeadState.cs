using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    Customer _customer;
    Spawner _spawner;

    public DeadState (Customer customer, Spawner spawner)
    {
        _customer = customer;
        _spawner = spawner;
    }

    // Start is called before the first frame update
    public void Tick(){}

    public void OnEnter()
    {
        _spawner.CallSpawnCustomer();
        LevelManager.instance.DestroyCustomer(_customer.gameObject, 2f);
    }

    public void OnExit(){}
}
