using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioClip[] _soundClips;

    AudioSource _audioSource;

    bool _isDriveSoundPlaying = false;

    PlayerEvents _playerEvents;

    float _breakSFXTimer = 0;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerEvents = GetComponent<PlayerEvents>();
    }

    void Start()
    {
        _playerEvents.onDriving += PlayDriveSound;
        _playerEvents.onBraking += PlayBreakSound;
    }

    void PlayDriveSound()
    {
        _breakSFXTimer += Time.deltaTime;

        if (!_isDriveSoundPlaying)
        {
            _isDriveSoundPlaying = true;
            PlaySoundClip(0, true);
        }
    }

    void PlayBreakSound()
    {
        ReduceBreakSFXTimer();
        if (_isDriveSoundPlaying)
        {   
            _isDriveSoundPlaying = false;
            
            if (_breakSFXTimer > 2f)
            {
                PlaySoundClip(1, false);
            }
            else
            {
                _audioSource.Stop();
            }
        }
        else if(_breakSFXTimer <=0)
        {
                _audioSource.Stop();     
        }
    }
        void ReduceBreakSFXTimer()
    {
        if(_breakSFXTimer > 0)
        {
            _breakSFXTimer -= Time.deltaTime*2;
        }
        else
        {
            _breakSFXTimer = 0;
        }
    }

    void PlaySoundClip(int num, bool isLoop)
    {
        _audioSource.clip = _soundClips[num];
        _audioSource.Play();
        _audioSource.loop = isLoop;
    }
    void OnDestroy()
    {
        _playerEvents.onDriving -= PlayDriveSound;
        _playerEvents.onBraking -= PlayBreakSound;       
    }
}
