using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public float TimeToWait = 5.0f;
    MeshRenderer renderer;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();

        renderer.enabled = false;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TimeToWait)
        {
            renderer.enabled = true;
            rb.useGravity = true;
        }
    }
}
