using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEvents : MonoBehaviour
{

    public event Action onTransacting = delegate {};
    public event Action onTransactionComplete = delegate {};

    public event Action onReWaiting = delegate {};

    Customer _customer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Transacting()
    {
        onTransacting();
    }

    public void TransactionComplete()
    {
        onTransactionComplete();
    }

    public void ReWaiting()
    {
        onReWaiting();
    }

 
}
