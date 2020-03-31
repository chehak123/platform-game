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

    [SerializeField]
    private Transform[] groundpoints;
    
    [SerializeField]                                           // this writing serializefield in brackets will include these fields in unity hub 
    private float groundradius;

    [SerializeField]
    private LayerMask whatisground;

    private bool checkisgrounded;
    private bool jump;
    [SerializeField]
    private bool aircontrol;

   [SerializeField]
    private float jumpforce;







    void Start()
    {
        facingright=true;                                               //initially he will always be facing towards right 
        myrigidbody=GetComponent<Rigidbody2D>();                       // helpS to develop relation between rigidbody defined in this and unity hub
        myanimator=GetComponent<Animator>();                         // develop relation between animator in unity hub nd myanimator
    }

    private void handlemovt(float horizontal)                           //function
    {              

        if(myrigidbody.velocity.y < 0)
        {
            myanimator.SetBool("land",true);                   //if we are falling then our velocity is neg and we ll do mark the land parameter as true
        }

        if(checkisgrounded ||aircontrol)                       
        { 
           myrigidbody.velocity= new Vector2(horizontal*movtspeed ,myrigidbody.velocity.y);
        }
        myanimator.SetFloat("speed",Mathf.Abs(horizontal)); 

        if(checkisgrounded && jump)                                    // if we are standing on goround and pressing the jump button then we are not grounded anymore
        {
            checkisgrounded=false;
            myrigidbody.AddForce(new Vector2(0,jumpforce));
            myanimator.SetTrigger("jump");
        }                
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
    private bool isgrounded()
    {
        if(myrigidbody.velocity.y<=0)                               // if we are falling down or we are not moving
        {
           foreach(Transform point in groundpoints)
           {
               Collider2D[] colliders= Physics2D.OverlapCircleAll(point.position,groundradius,whatisground);

               for(int i=0;i<colliders.Length;i++)
               {
                   if(colliders[i].gameObject != gameObject)        // if we are colliding with ground 
                   {
                       myanimator.ResetTrigger("jump");
                       myanimator.SetBool("land",false);        
                      return true;
                   }
               }
           }
        }

        return false;
    }

    private void handlelayers()
    {
        if(!checkisgrounded)
        {
            myanimator.SetLayerWeight(1,1);                 // ie air layer ki settings mein pointer ko 1 pe point karna hai
        }
        else
        {
            myanimator.SetLayerWeight(1,0);
        }
    }

    private void handleinput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump=true;
        }
    }

    private void resetvalues()

    {
        jump=false;
    }
    void FixedUpdate()                                                                      //main function
    {
        float horizontal= Input.GetAxis("Horizontal");
        checkisgrounded=isgrounded();                                    //checkisgrounded variable stores true or false telling whether the player is grounded or not
        handlemovt(horizontal);
        flip(horizontal);
        handlelayers();
        resetvalues();

    }

    void Update()
    {
        handleinput();
    }

    
}
