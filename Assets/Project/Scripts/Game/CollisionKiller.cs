using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionKiller : MonoBehaviour
{
    [Header("AddPoints")]
    public int value_cats; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "LavaOrb")
        {
            SceneManager.LoadScene("Death");
        }

        if (collision.gameObject.tag == "LavaWave")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            0, 0
            );
        }

        if (collision.gameObject.tag == "Cat")
        {

            if (collision.collider.GetType() == typeof(CircleCollider2D))
            {
                //add the wanted points of this prefab tp score, located in scoretext script
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += 1;
                //kill object
                Destroy(collision.gameObject);
            }
            if (collision.collider.GetType() == typeof(BoxCollider2D))
            {
                //add the wanted points of this prefab tp score, located in scoretext script
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += 100;
                //kill object
                Destroy(collision.gameObject);
            }
        }
        //Tagging objects
    }
}
