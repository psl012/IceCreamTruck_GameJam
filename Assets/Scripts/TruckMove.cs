using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _rotateSpeed;
    [SerializeField] AudioClip[] _audioClip;
    AudioSource _audioSource;
    Rigidbody _rigidBody;
    float _accelerate;
    float _steer;

    float _breakSFXTimer = 0;

    bool _isDriveSoundPlaying = false;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
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

        if (accelerate > 0)
        {
            _breakSFXTimer += Time.deltaTime;
            if (!_isDriveSoundPlaying)
            {
                _isDriveSoundPlaying = true;
                PlayDriveSound();
            }
        }
        else if(_accelerate == 0 && _isDriveSoundPlaying)
        {
            _isDriveSoundPlaying = false;
            if (_breakSFXTimer > 2f)
            {
                PlayBreakSound();
            }
            else 
            {
                _audioSource.Stop();
            }
            _breakSFXTimer = 0;
        }
    }

    void PlayDriveSound()
    {
        _audioSource.clip = _audioClip[0];
        _audioSource.Play();
        _audioSource.loop = true;
    }

    void PlayBreakSound()
    {
        _audioSource.clip = _audioClip[1];
        _audioSource.Play();
        _audioSource.loop = false;
    }
}
