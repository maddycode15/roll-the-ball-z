using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
 
 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime, 1);   // this line rotates the transform of the cube using the vector 3 data (data that has 3 vectors x y z) and rotates it by delta time.
    }
}
