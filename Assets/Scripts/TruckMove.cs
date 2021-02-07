using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _rotateSpeed;

    Rigidbody _rigidBody;
    float _accelerate;
    float _steer;
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _accelerate = Input.GetAxis("Vertical");      
        _steer = Input.GetAxis("Horizontal");  
    }

    void FixedUpdate()
    {
        MoveCharacter(_accelerate, _steer);
    }

    void MoveCharacter(float accelerate, float steer)
    {
        _rigidBody.AddForce(transform.forward * accelerate * _speed);
        transform.Rotate(0, steer * _rotateSpeed, 0);
    }
}
