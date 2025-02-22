using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour
{
   private bool _packageDelivered; 
   private ObjectInfo _objectInfo;
   private SpriteRenderer _spriteRenderer;
   private void Start()
   {
      // Find the event and subscribe to it 
      var eventHandler = GameObject.Find("EventHandler").GetComponent<Events>();
      eventHandler.OnPackageDelivered += PackageDelivered;

      // Find sprite renderer and object info 
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _spriteRenderer.enabled = false;
      _objectInfo = GetComponentInParent<ObjectInfo>();
   }

   /**
    * Enable SR only if package is not delivered
    */
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player") && !_packageDelivered)
      {
         _spriteRenderer.enabled = true;
      }
   }

   /**
    * Disable sprite renderer when player isnt there
    */
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         _spriteRenderer.enabled = false;
      }
   }

   /**
    * Listener for package delivered. If so, disable sprite right away
    */
   private void PackageDelivered(ObjectInfo obj)
   {
      if (obj.ObjectID != _objectInfo.ObjectID) return; // Check if the delivered package was for this object
      _spriteRenderer.enabled = false;
      _packageDelivered = true;
   }
   
   
}
