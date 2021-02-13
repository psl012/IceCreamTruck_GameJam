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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
       //     if (!_finishedBuying)
            {   
                _rigidBody.constraints = RigidbodyConstraints.None;
                Debug.Log("Dead" + collisionForce);
               // SpawnNext();
                Destroy(gameObject,2f);
            }
        }
    }
}
