using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0.0f;
    public float Speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        PrintMessage();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintMessage()
    {
        Debug.Log("Welcome to the Ant Game!!!");
        Debug.Log("Make your way around the Maze.");
        Debug.Log("Don't BUMP INTO Obsacles.");
    }

    void MovePlayer()
    {
        x = Speed * -Time.deltaTime * Input.GetAxis("Horizontal");
        z = Speed * -Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(x, y, z);
    }
}
