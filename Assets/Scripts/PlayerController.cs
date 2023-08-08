using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidbody2D1;
    public float speed;
        
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            rigidbody2D1.velocity=new Vector2(0,0);
        }
        else
        {
        if(Input.GetAxis("Horizontal")>0)
        {
            rigidbody2D1.velocity= new Vector2(speed,0);
        }
        else if(Input.GetAxis("Horizontal")<0)
        {
            rigidbody2D1.velocity=new Vector2(-speed,0);
        }

        if(Input.GetAxis("Vertical")>0)
        {
            rigidbody2D1.velocity=new Vector2(0,speed);
        }
        else if(Input.GetAxis("Vertical")<0)
        {
            rigidbody2D1.velocity=new Vector2(0,-speed);
        }

        else if(Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical")==0)
        {
            rigidbody2D1.velocity=new Vector2(0,0);
        }
        }
    }
 private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Door")
        {
        Debug.Log("level Cmplte");
        }
        if(other.tag=="walls")
        {
            Debug.Log("Collision Failed");
        }
    }
}