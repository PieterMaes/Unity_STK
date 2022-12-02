using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionKiller : MonoBehaviour
{
    [Header("AddPoints")]
    public int value_cats;

    private bool hard;

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
            if (this.GetComponent<BoxTapTile>().getHard == true)
            {
                //add the wanted points of this prefab tp score, located in scoretext script
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score -= value_cats*2;
                //kill object
                Destroy(collision.gameObject);
            }
            if (this.GetComponent<BoxTapTile>().getSoft == true){
                //add the wanted points of this prefab tp score, located in scoretext script
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += value_cats;
                //kill object
                Destroy(collision.gameObject);
            }
        }
        //Tagging objects
    }
}
