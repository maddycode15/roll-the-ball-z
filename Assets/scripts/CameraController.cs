using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public GameObject player;
    private Vector3 offset; // this stores the value of where the camera should go relitive to the player. it is vector 3 because it is supposed to take in data from 3 vectors, x , y and z.

    // Start is called before the first frame update
    void Start() // the code for this project is going to be stored in void start because it is supposed to happen at the start of the project but it only needs to calculate it once
    {
        offset = transform.position - player.transform.position;  // this causes the offset to be equal to the transform position - the players position
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;  // this line makes the transform position of the camera equal to the player transform position., plus the offset. the offset stops it from being directly on the player
    }
}
