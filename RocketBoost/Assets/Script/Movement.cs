using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Physics")]
    public Rigidbody rb;
    public float TurnRate = 1000;
    public float RotationThrust = 50;

    [Header("Audio Clips")]
    public AudioSource audio;
    public AudioClip MainEngine;
    public AudioClip GoalPoint;
    public AudioClip Crash;

    [Header("Particles")]
    public ParticleSystem LBooster;
    public ParticleSystem RBooster;
    public ParticleSystem LSmBooster;
    public ParticleSystem RSmBooster;

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
            BoostRocket();
        }
        else
            audio.Stop();
            RBooster.Stop();
            LBooster.Stop();
    }

    void BoostRocket()
    {
        rb.AddRelativeForce(Vector3.up * TurnRate * Time.deltaTime);

        if (!audio.isPlaying)
        {
            audio.PlayOneShot(MainEngine);
        }

        if (!RBooster.isPlaying && !LBooster.isPlaying)
        {
            //Debug.Log("Activated");
            RBooster.Play();
            LBooster.Play();
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            InputRotation(RotationThrust);

            if (!LSmBooster.isPlaying) { LSmBooster.Play(); }
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            InputRotation(-RotationThrust);

            if (!RSmBooster.isPlaying) { RSmBooster.Play(); }
        }
        else
            RSmBooster.Stop();
            LSmBooster.Stop();
    }

    void InputRotation(float TurnDirection)
    {
        rb.freezeRotation = true; //Freeze Rotation so it dosen't rotate.
        transform.Rotate(Vector3.forward * TurnDirection * Time.deltaTime);
    }
}
