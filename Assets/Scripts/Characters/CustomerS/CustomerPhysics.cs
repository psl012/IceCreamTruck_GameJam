using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPhysics : MonoBehaviour
{
    Rigidbody _rigidBody;
    Customer _customer;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _customer = GetComponent<Customer>();
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
            {   
                _rigidBody.constraints = RigidbodyConstraints.None;
                _customer._isDead = true;
                Debug.Log("Dead" + collisionForce);
            }
        }
    }
}
