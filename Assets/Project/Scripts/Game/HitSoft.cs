using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitSoft : MonoBehaviour
{
    public Sprite tapSprite;
    public int add_points;

    void hitSoft()
    {
        //render the sprite to a tap of the collider and enable the box collider
        this.GetComponent<SpriteRenderer>().sprite = tapSprite;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    //checks for collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LavaOrb")
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
            //add the wanted points of this prefab tp score, located in scoretext script
            GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += add_points;
            //kill object
            Destroy(collision.gameObject);
        }
    }
}
