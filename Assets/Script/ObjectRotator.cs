using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{

    public float rotationSpeed;
    public bool RotationAxisX;
    public bool RotationAxisY;
    public bool RotationAxisZ;

    private void Start()
    {
        this.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotationAxisX = true;
            RotationAxisY = false;
            RotationAxisZ = false;
            transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RotationAxisX = false;
            RotationAxisY = true;
            RotationAxisZ = false;
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RotationAxisX = false;
            RotationAxisY = false;
            RotationAxisZ = true;
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed);
        }


        if (RotationAxisX)
        {
            transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * rotationSpeed);
        }
        if (RotationAxisY)
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed);
        }
        if (RotationAxisZ)
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed);
        }
    }
}

