using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _rotateSpeed;
    Rigidbody _rigidBody;
    HandleInput _handleInput;

    PlayerEvents _playerEvents;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _handleInput = GetComponent<HandleInput>();
        _playerEvents = GetComponent<PlayerEvents>();
    }

    void FixedUpdate()
    {
        MoveCharacter(_handleInput._accelerate, _handleInput._steer);
    }

    void MoveCharacter(float accelerate, float steer)
    {
        _rigidBody.AddForce(transform.forward * accelerate * _speed);
        transform.Rotate(0, steer * _rotateSpeed, 0);

        if (accelerate > 0)
        {
            _playerEvents.Driving();
        }
        else if(accelerate == 0)
        {
            _playerEvents.Braking();
        }
    }
}
