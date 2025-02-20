using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    private Coroutine _timerCoroutine;
    [SerializeField, Tooltip("In seconds")] private float timeToDeliver;
    
    // Start is called before the first frame update
    void Start()
    {
        _timerCoroutine = StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        while (timeToDeliver > 0)
        {
            yield return new WaitForSeconds(1f);
            timeToDeliver--;
        }

        Debug.Log("passed");
    }

    public float TimeLeft
    {
        get => timeToDeliver;
        private set => timeToDeliver = value;
    }

}
