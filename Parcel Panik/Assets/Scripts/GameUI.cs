using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class GameUI : MonoBehaviour
{
    
    [SerializeField] private TMP_Text numPackagesText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text taskText;
    [SerializeField] private Vector3 textPositionRelativeToPlayer;
    private GameObject _player;
    private PackageCounterAndPay _packageCounterAndPay;
    private Timer _timer;
    [SerializeField] private string[] tasks;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Find objects   
        _player = GameObject.FindGameObjectWithTag("Player");
        _packageCounterAndPay = GameObject.Find("GameState").GetComponent<PackageCounterAndPay>();
        _timer = GameObject.Find("GameState").GetComponent<Timer>();
        // taskText = GameObject.Find("Tasks").GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateNumPackagesText();
        UpdateTimerText();
        UpdateTasksText();
    }

    /**
     * Displays the text counting the number of packages above the player 
     */
    private void UpdateNumPackagesText()
    {
        // set text and position
        numPackagesText.text = "" + _packageCounterAndPay.NumPackages + "/" + _packageCounterAndPay.TotalPackages;
        var playerPosition = _player.gameObject.transform.position;
        numPackagesText.gameObject.transform.position = new Vector3(playerPosition.x + textPositionRelativeToPlayer.x, playerPosition.y + textPositionRelativeToPlayer.y, playerPosition.z + textPositionRelativeToPlayer.z);
    }

    /**
     * Displays the time left to deliver packages
     */
    private void UpdateTimerText()
    {
        var totalTime = _timer.TimeLeft;
        var seconds = Mathf.FloorToInt(totalTime);
        var milliseconds = Mathf.FloorToInt((totalTime - seconds) * 1000);
        timerText.text = seconds + ":" + milliseconds.ToString("00");
    }

    /**
     * Displays the current task
     */
    private void UpdateTasksText()
    {
        taskText.text = _packageCounterAndPay.NumPackages == _packageCounterAndPay.TotalPackages ? tasks[1] : tasks[0];
    }
    
}
