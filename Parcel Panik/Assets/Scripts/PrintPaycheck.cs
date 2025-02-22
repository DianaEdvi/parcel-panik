using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrintPaycheck : MonoBehaviour
{
    private Events _eventHandler;
    [SerializeField] private List<string> names;
    private List<TMP_Text> texts; 
    private TMP_Text text;
    private PackageCounterAndPay _packageCounterAndPay;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _eventHandler = GameObject.Find("EventHandler").GetComponent<Events>();
        _packageCounterAndPay = GetComponent<PackageCounterAndPay>();
        names = new List<string>();
        _eventHandler.OnPackageDelivered += StoreNames;
        _eventHandler.OnUndesirableHit += StoreNames;

        texts = new List<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Credits") return; // Only run in Credits scene
    }
    
    // on package delivers, take the amount and 

    private void StoreNames(ObjectInfo obj)
    {
        names.Add(obj.Name + ": " + obj.Amount);
    }
    
    public List<string> GetNames()
    {
        return new List<string>(names); // Returning a copy to prevent external modification
    }
}
