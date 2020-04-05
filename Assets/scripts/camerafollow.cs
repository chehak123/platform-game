using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{

    [SerializeField]
    private float xmax;

    [SerializeField]
    private float ymax;

    [SerializeField]
    private float xmin;

    [SerializeField]
    private float ymin;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
       
       target=GameObject.Find("player").transform;

    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= new Vector3(Mathf.Clamp(target.position.x,xmin,xmax), Mathf.Clamp(target.position.y,ymin,ymax),transform.position.z);
        // above here we are clamping the positions so  that it does not move above or below the min and max values
    
    
    }


  
}


