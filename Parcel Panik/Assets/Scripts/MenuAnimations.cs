using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimations : MonoBehaviour
{
    [SerializeField] private GameObject waypointParent;
    [SerializeField] private GameObject startingWaypoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool randomize;
    [SerializeField] private GameObject mail;
    private Transform[] _waypoints;
    private int _currentIndex = 0;
    private Sprite[] mailSprites;
    private Sprite currentMailSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        if (randomize)
        {
            mailSprites = Resources.LoadAll<Sprite>("small_mail");
            Randomize();

        }
        
        
        // Store all way points in an array 
        var childCount = waypointParent.gameObject.transform.childCount;
        _waypoints = new Transform[childCount];

        for (var i = 0; i < childCount; i++)
        {
            _waypoints[i] = waypointParent.gameObject.transform.GetChild(i).gameObject.transform;
        }
        
        // Set the initial position of the sprite 
        transform.position = startingWaypoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TranslateSprite();
    }

    /**
     * Move the sprite towards each of its waypoints, then reset it once it is off the screen
     * First and last waypoints need to be off screen 
     */
    private void TranslateSprite()
    {
        if (_waypoints.Length == 0) return;

        // Move towards the next waypoint
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentIndex].transform.position, speed * Time.deltaTime);
        
        
        // If we reach the waypoint, move to the next one
        if (!(Vector3.Distance(transform.position, _waypoints[_currentIndex].position) < 0.1f)) return;
        
        // Reset position of sprite
        if (_currentIndex == _waypoints.Length - 1)
        {
            transform.position = _waypoints[0].transform.position;
            _currentIndex = 0;
            Randomize();
            return;
        }
        _currentIndex = (_currentIndex + 1);

    }

    private void Randomize()
    {
        if (mail == null)
        {
            return;
        }

        if (mailSprites == null || mailSprites.Length == 0)
        {
            return;
        }

        if (!randomize) return;
        
        var index = Random.Range(0, mailSprites.Length); // Random index
        mail.GetComponent<Image>().sprite = mailSprites[index];


    }
}
