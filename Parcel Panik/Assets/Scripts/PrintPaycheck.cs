using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrintPaycheck : MonoBehaviour
{
    private Events _eventHandler;
    private List<string> names;
    private TMP_Text[] texts; 
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
        // _eventHandler.OnGameOver += PrintInfo;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Credits") return; // Only run in Credits scene
    }
    
    // on package delivers, take the amount and 

    private void StoreNames(ObjectInfo obj)
    {
        names.Add(obj.Name);
    }

    private void PrintInfo()
    {
        // Create a new Canvas if one doesn't exist
        GameObject canvasObj = new GameObject("CreditsCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay; // Set to overlay so it's visible
        canvasObj.AddComponent<CanvasScaler>(); // Optional: Scale UI properly
        canvasObj.AddComponent<GraphicRaycaster>(); // Optional: Enable UI interactions

        texts = new TMP_Text[names.Count];
        var namesArr = names.ToArray();

        for (int i = 0; i < namesArr.Length; i++)
        {
            TMP_Text newText = Instantiate(text, canvasObj.transform); // Attach to new Canvas
            newText.text = namesArr[i]; // Assign text
            texts[i] = newText; // Store reference
            Debug.Log(texts[i]);
        }

    }




}
