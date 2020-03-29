using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    private Rigidbody2D myrigidbody;


    // Start is called before the first frame update
    void Start()
    {
       myrigidbody=GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        float horizontal= Input.GetAxis("Horizontal");
      
        Handlemovement(horizontal);
    }


    private void Handlemovement(float horizontal){

        myrigidbody.velocity= new Vector2(horizontal,myrigidbody.velocity.y);
    }
}


