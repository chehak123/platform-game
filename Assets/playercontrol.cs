using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{

    private Rigidbody2D myrigidbody;
    
    private Animator myanimator;
    [SerializeField]
    private float movtspeed;
    private bool facingright;
    

    void Start()
    {
        facingright=true;                                               //initially he will always be facing towards right 
        myrigidbody=GetComponent<Rigidbody2D>();                       // helpS to develop relation between rigidbody defined in this and unity hub
        myanimator=GetComponent<Animator>();                         // develop relation between animator in unity hub nd myanimator
    }

    private void handlemovt(float horizontal)                           //function
    {                                        
        myrigidbody.velocity= new Vector2(horizontal*movtspeed ,myrigidbody.velocity.y);
        myanimator.SetFloat("speed",Mathf.Abs(horizontal));                 
    }

    private void flip(float horizontal)
    {
         if(horizontal>0 && !facingright || horizontal<0 && facingright)
         {
            facingright=!facingright;
            Vector3 thescale=transform.localScale;           //access to player localscale
            thescale.x*=-1;                                  //we have multiplied the x value of scale with -1 to change the direction
            transform.localScale=thescale;
         }
    }

    void FixedUpdate()                                                                      //main function
    {
        float horizontal= Input.GetAxis("Horizontal");
        handlemovt(horizontal);
        flip(horizontal);
    }
}
