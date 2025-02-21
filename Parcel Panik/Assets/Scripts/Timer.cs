using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    private Coroutine _timerCoroutine;
    [SerializeField, Tooltip("In seconds")] private float timeToDeliver;
    private float _maxTime;

    private void Start()
    {
        _maxTime = timeToDeliver; // save max time for clamp 
    }

    private void Update()
    {
        if (timeToDeliver <= 0) return; //Stop subtracting if below 0
        
        timeToDeliver -= Time.deltaTime; // Timer 
        timeToDeliver = Mathf.Clamp(timeToDeliver, 0, _maxTime); // Clamp to 0 
        Debug.Log(timeToDeliver);
    }

    // Getter/setter
    public float TimeLeft
    {
        get => timeToDeliver;
        private set => timeToDeliver = value;
    }

}
