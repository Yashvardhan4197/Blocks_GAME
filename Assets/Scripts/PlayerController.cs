using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2d rigidbody2D;
    public speed float;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input.getAxis("Horizontal")>0)
        {
            rigidbody2D.Velocity = new vector2(speed, 0f);
        }
        
    }
}
