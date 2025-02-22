using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintPaycheck : MonoBehaviour
{
    private Events _eventHandler;
    private List<string> names;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _eventHandler = GameObject.Find("EventHandler").GetComponent<Events>();
        names = new List<string>();
        _eventHandler.OnPackageDelivered += StoreNames;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // on package delivers, take the amount and 

    private void StoreNames(ObjectInfo obj)
    {
        names.Add(obj.Name);
    }

    private void PrintInfo()
    {
        
    }
    
    
    
}
