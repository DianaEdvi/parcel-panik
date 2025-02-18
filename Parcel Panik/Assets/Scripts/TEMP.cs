using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP : MonoBehaviour
{
   private void Start()
   {
      GetComponent<SpriteRenderer>().enabled = false;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         Debug.Log("enter");
         GetComponent<SpriteRenderer>().enabled = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         Debug.Log("exit");
         GetComponent<SpriteRenderer>().enabled = false;
      }
   }
}
