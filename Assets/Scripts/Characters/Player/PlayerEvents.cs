using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{

    public event Action onDriving = delegate{};

    public event Action onBraking = delegate{};
    
    public void Driving()
    {
        onDriving();
    }

    public void Braking()
    {
        onBraking();
    }
}
