using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedState : IState
{
    Customer _customer;

    public FinishedState(Customer customer)
    {
        _customer = customer;
    }

    public void Tick()
    {

    }

    public void OnEnter()
    {
        AudioClip kachingSound = _customer._audioClip[0];
        _customer._audioSource.PlayOneShot(kachingSound);
        _customer.SpawnNext();
        _customer.CustomerDestroy(2);   
    }

    public void OnExit()
    {

    }
}
