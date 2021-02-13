using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSounds : MonoBehaviour
{
    [SerializeField] AudioClip _soldSound;  

    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _soldSound;
    }

    public void PlaySoldSound()
    {
        _audioSource.Play();
    }
}
