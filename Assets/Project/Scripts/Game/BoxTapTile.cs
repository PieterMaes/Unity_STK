using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTapTile : MonoBehaviour
{
    public bool enabled;
    public bool hard;
    public bool soft;

    public Sprite noneSprite;
    public Sprite boxSprite;
    public Sprite tapSprite;
    private BoxCollider2D colliderBox;
    private CircleCollider2D colliderTap;

    // Start is called before the first frame update

    void ChangeSprite(Sprite sp)
    {
        this.GetComponent<SpriteRenderer>().sprite = sp;
    }

    void Start()
    {
        colliderBox = this.GetComponent<BoxCollider2D>();
        colliderTap = this.GetComponent<CircleCollider2D>();
        ChangeSprite(noneSprite);
        colliderBox.enabled = false;
        colliderTap.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;

        if (Input.GetKeyDown(KeyCode.B))
        {
            this.GetComponent<SpriteRenderer>().sprite = boxSprite;
            this.GetComponent<BoxCollider2D>().enabled = true;
            hard = true;
            colliderBox.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.B)) {
            this.GetComponent<SpriteRenderer>().sprite = noneSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
            hard = false;
            colliderBox.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            this.GetComponent<SpriteRenderer>().sprite = tapSprite;
            this.GetComponent<BoxCollider2D>().enabled = true;
            soft = true;
            colliderBox.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            this.GetComponent<SpriteRenderer>().sprite = noneSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
            soft = false;
            colliderBox.enabled = false;
        }
    }

    public bool getHard()
    {
        return hard;
    }

    public bool getSoft()
    {
        return soft;
    }
}
