using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "LavaOrb")
        {

        }

        if (collision.gameObject.tag == "LavaWave")
        {

        }

        if (collision.gameObject.tag == "Cat")
        {

        }
        //Tagging objects
    }
}
