using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource audio;
    public float TurnRate = 1000;
    public float RotationThrust = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
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

            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
            audio.Stop();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            InputRotation(RotationThrust);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
