using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class GameUI : MonoBehaviour
{
    
    [SerializeField] private TMP_Text text;
    [SerializeField] private Vector3 textPositionRelativeToPlayer;
    private GameObject _player;
    private PackageCounterAndPay _packageCounterAndPay;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Find objects   
        _player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponentInChildren<TMP_Text>(); // Might have to change if more text gets put on screen 
        _packageCounterAndPay = GameObject.Find("PackageCounter").GetComponent<PackageCounterAndPay>();
    }

    // Update is called once per frame
    private void Update()
    {
        // set text and position
        text.text = "" + _packageCounterAndPay.NumPackages + "/" + _packageCounterAndPay.TotalPackages;
        var playerPosition = _player.gameObject.transform.position;
        text.gameObject.transform.position = new Vector3(playerPosition.x + textPositionRelativeToPlayer.x, playerPosition.y + textPositionRelativeToPlayer.y, playerPosition.z + textPositionRelativeToPlayer.z);
    }
}
