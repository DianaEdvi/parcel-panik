using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDelivery : MonoBehaviour
{
    private ObjectInfo _objectInfo;
    private bool _isWithinBounds;
    private bool _packageDelivered;
    [SerializeField] private SpriteRenderer mailSprite;

    private void Start()
    {
        _objectInfo = GetComponent<ObjectInfo>(); // Find the component 
    }
    
    private void Update()
    {
    // Check for Enter key press here
        if (!_isWithinBounds || !Input.GetKeyDown(KeyCode.Return) || _packageDelivered) return;
        Events.Instance.OnPackageDelivered?.Invoke(_objectInfo); // Fire event
        _packageDelivered = true;
        mailSprite.enabled = false;
    }

    /**
     * Check if being collided with 
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Events.Instance == null || !other.gameObject.CompareTag("Player")) return;

        _isWithinBounds = true; // Set flag to allow key press detection

        // If the current object is the post office, fire the event 
        if (!_objectInfo.IsPostOffice) return;
        var events = GameObject.Find("EventHandler").GetComponent<Events>();
        events.OnPostOfficeCollision?.Invoke(_objectInfo);
    }

    // Check if player left 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        _isWithinBounds = false; // Reset the flag when player exits trigger
    }
}