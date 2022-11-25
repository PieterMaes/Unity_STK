using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTapTile : MonoBehaviour
{
    public bool enabled;
    public SpriteRenderer spriteRenderer;
    public Sprite noneSprite;
    public Sprite boxSprite;
    public Sprite tapSprite;

    // Start is called before the first frame update

    void ChangeSprite(Sprite sp)
    {
        spriteRenderer.sprite = sp;
    }

    void Start()
    {
        ChangeSprite(noneSprite);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //this.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //this.GetComponent<Collider2D>().enabled = true;
            ChangeSprite(tapSprite);
            enabled = true;
        }
        
    }
}
