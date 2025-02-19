using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PackageCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var moneyHandler = GameObject.Find("MoneyTracker").GetComponent<MoneyHandler>();
        moneyHandler.OnPackageDelivered += IncrementPackageCounter;
        
        TotalPackages = GameObject.FindGameObjectsWithTag("House").Length; 

    }

    private void IncrementPackageCounter(ObjectInfo objectInfo)
    {
        if (objectInfo.gameObject.CompareTag("House"))
        {
            NumPackages++;
        }
    }
    
    // Getters and setters
    public int NumPackages { get; private set; }
    public int TotalPackages { get; private set; }
}
