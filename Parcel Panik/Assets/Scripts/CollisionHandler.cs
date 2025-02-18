using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private ObjectInfo _objectInfo;
    private bool _hasTriggered;
    private bool _packageDelivered;

    private void Start()
    {
        _objectInfo = GetComponent<ObjectInfo>(); // Find the component 
    }
    
    private void Update()
    {
        // Check for Enter key press here
        if (!_hasTriggered || !Input.GetKeyDown(KeyCode.Return) || _packageDelivered) return;
        
        MoneyHandler.Instance.OnPackageDelivered?.Invoke(_objectInfo); // Fire event
        _packageDelivered = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (MoneyHandler.Instance == null || !other.gameObject.CompareTag("Player")) return;

        _hasTriggered = true; // Set flag to allow key press detection
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        _hasTriggered = false; // Reset the flag when player exits trigger
    }
}