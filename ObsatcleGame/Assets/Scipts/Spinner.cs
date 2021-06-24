using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float xAng;
    public float yAng;
    public float zAng;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAng, yAng, zAng);
    }
}
