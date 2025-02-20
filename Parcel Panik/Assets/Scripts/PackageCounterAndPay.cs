using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PackageCounterAndPay : MonoBehaviour
{
    [SerializeField] private static int _totalMoney; // money money money 
    private Events _eventHandler;
    private bool _winGame;

    // Start is called before the first frame update
    private void Start()
    {
        
        TotalPackages = GameObject.FindGameObjectsWithTag("House").Length;
        _eventHandler = GameObject.Find("EventHandler").GetComponent<Events>();
        
        _eventHandler.OnPackageDelivered += IncrementPackageCounter;
        _eventHandler.OnPackageDelivered += ChangePay; // Subscribe to the event once (event listener)
        _eventHandler.OnUndesirableHit += ChangePay;
        _eventHandler.OnPostOfficeCollision += CheckGameOver;

    }
    
    private void IncrementPackageCounter(ObjectInfo objectInfo)
    {
        if (objectInfo.gameObject.CompareTag("House"))
        {
            NumPackages++;
        }
    }
    
    
    /**
     * Increment/decrement the total pay depending on which object was used
     */
    private static void ChangePay(ObjectInfo specifics)
    {
        _totalMoney += specifics.Amount;
        Debug.Log(_totalMoney);
    }

    /**
     * Checks if the player has won or lost  
     */
    private void CheckGameOver(ObjectInfo obj)
    {
        
        if (NumPackages == TotalPackages)
        {
            _winGame = true; // temp
            _eventHandler.OnGameOver?.Invoke(true);
        }
        else // if timer runs out 
        {
            _eventHandler.OnGameOver?.Invoke(false);
            _winGame = false; // temp
        }

        Debug.Log(_winGame);
        
    }
    
    
    // Getters and setters
    public int NumPackages { get; private set; }
    public int TotalPackages { get; private set; }
}
