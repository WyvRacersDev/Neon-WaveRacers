using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public bool x, y, z;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (x)
        transform.Rotate(speed, 0, 0);

        if(y)
        transform.Rotate(0,speed, 0);

        if(z) 
        transform.Rotate(0,0, speed);
    }
}
