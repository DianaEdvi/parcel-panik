using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pointer : MonoBehaviour
{
    private GameObject[] houses;
    [SerializeField] private GameObject postOffice;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.position.x, player.position.y + 2, player.position.z);
        PointToClosestHouse();
        
    }

    private void PointToClosestHouse()
    {
        if (houses.Length == 0) return; // Prevent errors if no houses exist

        var closestHouse = postOffice; // Post office if all are found
        var closestDistance = Vector3.Distance(transform.position, closestHouse.transform.position);

        foreach (var house in houses)
        {
            var mailTransform = house.transform.Find("Mail"); 
            var mailSprite = mailTransform.GetComponent<SpriteRenderer>();
            if (mailSprite.enabled == false)
            {
                continue;
            }
            var distance = Vector3.Distance(transform.position, house.transform.position);
            if (!(distance < closestDistance)) continue;
            closestHouse = house;
            closestDistance = distance;
        }

        // Get direction to closest house
        var direction = closestHouse.transform.position - transform.position;

        // Calculate angle (for X-axis)
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Adjust for Y-axis (green arrow)
        angle -= 90f; // Rotating by -90° aligns the Y-axis to point forward
        
        // Apply rotation
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
