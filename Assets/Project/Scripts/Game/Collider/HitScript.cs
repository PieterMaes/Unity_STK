using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitScript : MonoBehaviour
{
    
    [Header("AudioSounds")] public AudioClip catMeow;
    public AudioClip catAngry;
    public AudioClip wizardOof;
    
    [Header("Tap sprites")]
    public Sprite boxSprite;
    public Sprite tapSprite;
    public Sprite noneSprite;
    public int subtract_points = 5;
    public int add_points = 10;
   // public Collision2D collision;
    bool hardhit;

    public GameObject player;
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    //public static System.Threading.Tasks.Task Delay(TimeSpan delay);
    public void resetLayout()
    {
        this.GetComponent<SpriteRenderer>().sprite = noneSprite;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void hitTile(bool hard) {

        if (hard == false) { hitSoft(); }
        else { hitHard(); }
    }

    public void hitHard()
    {
        //render the sprite to a tap of the collider and enable the box collider
        this.GetComponent<SpriteRenderer>().sprite = boxSprite;
        this.GetComponent<BoxCollider2D>().enabled = true;
        hardhit = true;
        Invoke("resetLayout", 1);
    }

    public void hitSoft()
    {
        //render the sprite to a tap of the collider and enable the box collider
        this.GetComponent<SpriteRenderer>().sprite = tapSprite;
        this.GetComponent<BoxCollider2D>().enabled = true;
        hardhit = false;
        Invoke("resetLayout", 1);//this will happen after 2 seconds
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LavaOrb")
        {
            if (player.gameObject.GetComponent<Health>().health >= 2)
            {
                player.gameObject.GetComponent<Health>().health -= 1;
            }
            else
            {
                Debug.Log("LavaOrb punched");
                SceneManager.LoadScene("Death");
                Destroy(collision.gameObject);
            }
        }
        Debug.Log("In Triggermethod");

        if (collision.gameObject.tag == "Cat")
        {
            //add the wanted points of this prefab tp score, located in scoretext script
            if (hardhit == true)
            {   
                AudioSource.PlayClipAtPoint(catAngry, transform.position);
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().SetScore(-subtract_points);
            }
            else
            {
                AudioSource.PlayClipAtPoint(catMeow, transform.position);
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().SetScore(add_points);
            }
            //kill object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Wizard"))
        {
            AudioSource.PlayClipAtPoint(wizardOof, transform.position);
            Debug.Log("Wizard punched");
            collision.gameObject.GetComponent<Wizard1>().hitWizard();
            var text = GameObject.Find("ScoreText");
            text.transform.GetComponent<ScoreText>().SetScore(5);
        }
    }
}
