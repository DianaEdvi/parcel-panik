using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayText : MonoBehaviour
{
    private PrintPaycheck _paycheck;
    [SerializeField] private List<string> names;
    [SerializeField] private TMP_Text textPrefab; // Assign a prefab in Inspector
    [SerializeField] private Transform startPosition;
    private int currentOffset = 0; 
    [SerializeField] private int offset = 15;
    private static float totalMoney;
    private TMP_Text totalText;
    [SerializeField] private string bullyText;
    private Color textColor;

    private TMP_Text _text;
    private GameObject _canvas;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameState") == null) return;
        _paycheck = GameObject.Find("GameState").GetComponent<PrintPaycheck>();
        _canvas = GameObject.Find("Scroll");
        totalMoney = PackageCounterAndPay.TotalMoney;
        totalText = GameObject.Find("total").GetComponent<TMP_Text>();

        names = _paycheck.GetNames();

        if (names.Count == 0)
        {
            var newText = Instantiate(textPrefab, _canvas.transform); // Instantiate from prefab
            newText.transform.position = new Vector3(startPosition.position.x, startPosition.position.y - 10, startPosition.position.z);
            currentOffset -= offset;
            newText.text = bullyText; // Set the text to the name
        }

        foreach (var n in names)
        {
            var newText = Instantiate(textPrefab, _canvas.transform); // Instantiate from prefab
            newText.transform.position = new Vector3(startPosition.position.x, startPosition.position.y + currentOffset, startPosition.position.z);
            currentOffset -= offset;
            newText.text = n; // Set the text to the name

            if (n.Contains("Mailbox"))
            {
                newText.color = Color.red;
            }
        }

        totalText.text += totalMoney;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
