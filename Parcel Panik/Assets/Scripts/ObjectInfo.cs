using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * The data for the different objects being triggered by the player 
 */
public class ObjectInfo : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private bool isPostOffice;
    // can include other variables like audio clips, animations, etc 

    private void Start()
    {
        ObjectID = gameObject.name; // Set id to the name of the object
    }

    // Getters and setters 
    public string ObjectID { get; private set; }
    public int Amount
    {
        get => amount;
        set => amount = value;
    }
    public bool IsPostOffice
    {
        get => isPostOffice;
        set => isPostOffice = value;
    }

}
