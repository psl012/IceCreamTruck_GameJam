using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput:MonoBehaviour
{
    public float _accelerate {get; set;}
    public float _steer {get; set;}

    void Update()
    {
        _accelerate = Input.GetAxis("Vertical");      
        _steer = Input.GetAxis("Horizontal");  
    }

}
