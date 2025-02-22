using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private GameObject[] wheels;

    // Update is called once per frame
    void Update()
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        foreach (var wheel in wheels)
        {
            wheel.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }
    }
}
