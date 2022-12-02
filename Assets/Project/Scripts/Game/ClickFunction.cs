using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickFunction : MonoBehaviour
{
    [Header ("Harmful Object?")]
    public bool harmful;

    [Header("New Speed Variables")]
    public float newX_Speed;
    public float newY_Speed;

    [Header("AddPoints")]
    public int add_points;

    [Header("Destroy object after click?")]
    public bool destroy;

    public void OnMouseDown()
    {
        //when object clicked, set speed to 0
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            newX_Speed, newY_Speed
            );

        if (!harmful)
        {
            //add the wanted points of this prefab tp score, located in scoretext script
            GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().SetScore(add_points);
            if (destroy == true)
            { 
                //kill object
                Destroy(this.gameObject);
            }
            
        }
        else
        {
            SceneManager.LoadScene("Death");
        }
    }
}
