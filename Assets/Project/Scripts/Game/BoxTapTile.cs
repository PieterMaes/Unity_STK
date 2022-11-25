using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTapTile : MonoBehaviour
{
    public bool enabled;
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
            colliderBox.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.B)) {
            this.GetComponent<SpriteRenderer>().sprite = noneSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
            colliderBox.enabled = false;    
        }

        {
            this.GetComponent<CircleCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = tapSprite;
            colliderTap.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = noneSprite;
            colliderTap.enabled = false;
        }

    }
}
