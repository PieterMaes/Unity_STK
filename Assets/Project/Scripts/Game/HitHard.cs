using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitHard : MonoBehaviour
{
    public Sprite boxSprite;
    public int subtract_points;

    void hitHard()
    {
        //render the sprite to a tap of the collider and enable the box collider
        this.GetComponent<SpriteRenderer>().sprite = boxSprite;
        this.GetComponent<BoxCollider2D>().enabled = true;

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
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
            GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score -= subtract_points;
            //kill object
            Destroy(collision.gameObject);
        }
    }
}
