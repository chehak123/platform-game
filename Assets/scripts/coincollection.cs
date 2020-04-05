using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coincollection : MonoBehaviour
{
    // public Text score;
    // private int scorevalue=0;
   
private void OnCollisionEnter2D(Collision2D collision)
{

    if(collision.gameObject.tag=="coin")
    {
        ScoreTextScript.coinAmount++;
       Destroy(collision.gameObject);

    }
}

// void SetScore()
// {
//     score.text="coins:"+scorevalue;
// }

}

