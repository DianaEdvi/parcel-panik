using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PackageCounterAndPay : MonoBehaviour
{
    [SerializeField] private static int _totalMoney; // money money money 

    // Start is called before the first frame update
    private void Start()
    {
        var events = GameObject.Find("EventHandler").GetComponent<Events>();
        events.OnPackageDelivered += IncrementPackageCounter;
        
        TotalPackages = GameObject.FindGameObjectsWithTag("House").Length; 
        
        events.OnPackageDelivered += ChangePay; // Subscribe to the event once (event listener)
        events.OnUndesirableHit += ChangePay;

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
    
    // Getters and setters
    public int NumPackages { get; private set; }
    public int TotalPackages { get; private set; }
}
