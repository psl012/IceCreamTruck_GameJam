using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSounds : MonoBehaviour
{
    [SerializeField] AudioClip _soldSound;  

    AudioSource _audioSource;

    CustomerEvents _customerEvents;

    void Awake()
    {
        _customerEvents = GetComponent<CustomerEvents>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _soldSound;
    
    }

    void Start()
    {
        _customerEvents.onTransactionComplete += PlaySoldSound;
    }

    void PlaySoldSound()
    {
        _audioSource.Play();
    }
}
