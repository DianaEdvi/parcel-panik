using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndesirableObjectCollision : MonoBehaviour
{
    private ObjectInfo _objectInfo;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite destroyedSprite; 
    private Events _eventHandler;
    private bool _isDestroyed;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        // Find components 
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _objectInfo = GetComponent<ObjectInfo>();
        _eventHandler = GameObject.Find("EventHandler").GetComponent<Events>();
        _audioSource = GetComponent<AudioSource>();
        
        // Subscribe to event
        _eventHandler.OnUndesirableHit += ChangeSprite;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If collided, fire event 
        if (other.gameObject.CompareTag("Player") && !_isDestroyed)
        {
            _eventHandler.OnUndesirableHit?.Invoke(_objectInfo);
        }    
    }

    // Checks if the ID matches that of the current object, and if so, changes its sprite to destroyed 
    private void ChangeSprite(ObjectInfo obj)
    {
        if (obj.ObjectID != _objectInfo.ObjectID) return; // Check if the delivered package was for this object
        _spriteRenderer.sprite = destroyedSprite;
        _isDestroyed = true;
        
        // Play audio
        _audioSource.Play();
    }
    
}
