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
   [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _objectInfo = GetComponent<ObjectInfo>(); // Find the component 
        _spriteRenderer.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (MoneyHandler.Instance == null) return;

        if (!other.gameObject.CompareTag("Player")) return;
        MoneyHandler.Instance.OnPackageDelivered?.Invoke(_objectInfo);
        _spriteRenderer.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        _spriteRenderer.enabled = false;
    }
    
    

}
