using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    
    public Action<ObjectInfo> OnPackageDelivered; // Define event 
    public Action<ObjectInfo> OnUndesirableHit; // Define event 
    public Action<ObjectInfo> OnPostOfficeCollision; // Define event 
    public Action OnGameOver;
    
    public static Events Instance { get; private set; } // Make only one instance of the money tracker (avoid accidental duplicates) 
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }



}
