using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Responsible for firing the package delivered event upon being triggered by player 
 */
public class CollisionHandler : MonoBehaviour
{
   private ObjectInfo _objectInfo;

    private void Start()
    {
        _objectInfo = GetComponent<ObjectInfo>(); // Find the component 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (MoneyHandler.Instance == null) return; // Return if there is no instance 
        
        MoneyHandler.Instance.OnPackageDelivered?.Invoke(_objectInfo); // Fire the event 
        GetComponent<Collider2D>().enabled = false; // Disable collider to avoid multi-counting 
    }
}
