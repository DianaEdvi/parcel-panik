using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Events _eventHandler;
    private PackageCounterAndPay _packageCounterAndPay;
    private Timer _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        _packageCounterAndPay = GameObject.Find("GameState").GetComponent<PackageCounterAndPay>();
        _timer = GameObject.Find("GameState").GetComponent<Timer>();
        _eventHandler = GameObject.Find("EventHandler").GetComponent<Events>();
        _eventHandler.OnPostOfficeCollision += CheckGameOver;
        _eventHandler.OnGameOver += LoadCredits;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer.TimeLeft == 0) // and already called 
        {
            _eventHandler.OnGameOver?.Invoke();
        }
        
    }
    
    /**
   * Checks if the player has won or lost
   */
    private void CheckGameOver(ObjectInfo obj)
    {
        
        if (_packageCounterAndPay.NumPackages == _packageCounterAndPay.TotalPackages)
        {
            _eventHandler.OnGameOver?.Invoke();
        }
    }

    private void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
