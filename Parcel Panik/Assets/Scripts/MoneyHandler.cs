using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Used to track the total money the player has made. Should only have one in total. I just made a prefab so you can use it in your scene if you want. 
 */
public class MoneyHandler : MonoBehaviour
{
    public static MoneyHandler Instance { get; private set; } // Make only one instance of the money tracker (avoid accidental duplicates) 

    public Action<ObjectInfo> OnPackageDelivered; // Define event 
    [SerializeField] private static int _totalMoney; // money money money 

    private void Awake()
    {
        // Delete any duplicate instances of the money handler 
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Subscribe to the event 
        OnPackageDelivered += ChangePay; // Subscribe to the event once (event listener)
        // Make a PlayAudio listener in AudioManager and pass in collisionInfo as arg 
        // Make PlayAnimation listener in another script (DeliveryAnimationManager? idk how we want to do that yet)  
        // Make Game Over listener that checks if isPostOffice and if all packages were delivered
    }

    /**
     * Increment/decrement the total pay depending on which object was used
     */
    private static void ChangePay(ObjectInfo specifics)
    {
        _totalMoney += specifics.Amount;
        Debug.Log(_totalMoney);
    }
}

