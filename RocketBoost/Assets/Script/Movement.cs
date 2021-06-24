using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float TurnRate = 1000;
    public float RotationThrust = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Boost();
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * TurnRate * Time.deltaTime);
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            InputRotation(RotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            InputRotation(-RotationThrust);
        }
    }

    void InputRotation(float TurnDirection)
    {
        rb.freezeRotation = true; //Freeze Rotation so it dosen't rotate.
        transform.Rotate(Vector3.forward * TurnDirection * Time.deltaTime);
    }
}
