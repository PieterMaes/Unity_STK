using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitScript : MonoBehaviour
{
    public Sprite boxSprite;
    public Sprite tapSprite;
    public Sprite noneSprite;
    public int subtract_points = 5;
    public int add_points = 10;
    public Collision2D collision;
    bool hardhit;
    //public static System.Threading.Tasks.Task Delay(TimeSpan delay);

    public void hitTile(bool hard) {
        if (hard == false) { hitSoft(); }
        else { hitHard(); }
    }
    /*
    public async Task waitMethod()
    {
        await Task.Run(async () =>
        {
            Debug.Log("Start");
            await Task.Delay(5000);
            Debug.Log("Done");
        });
        Debug.Log("All done");

        this.GetComponent<SpriteRenderer>().sprite = tapSprite;
    }
    */
    public void hitHard()
    {
        //render the sprite to a tap of the collider and enable the box collider
        this.GetComponent<SpriteRenderer>().sprite = boxSprite;
        this.GetComponent<BoxCollider2D>().enabled = true;
        hardhit = true;
        //waitMethod();
    }

    public void hitSoft()
    {
        //render the sprite to a tap of the collider and enable the box collider
        this.GetComponent<SpriteRenderer>().sprite = tapSprite;
        this.GetComponent<BoxCollider2D>().enabled = true;
        hardhit = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LavaOrb")
        {
            Debug.Log("LavaOrb punched");
            SceneManager.LoadScene("Death");
        }

        if (collision.gameObject.tag == "LavaWave")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (collision.gameObject.tag == "Cat")
        {
            //add the wanted points of this prefab tp score, located in scoretext script
            if (hardhit == true)
            {   
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().SetScore(-subtract_points);
            }
            else
            {
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().SetScore(add_points);
            }
            //kill object
            Destroy(collision.gameObject);
        }
    }
}
