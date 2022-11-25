using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTapTile : MonoBehaviour
{
    public bool enabled;
    public Sprite noneSprite;
    public Sprite boxSprite;
    public Sprite tapSprite;
    private Collider2D colider;

    // Start is called before the first frame update

    void ChangeSprite(Sprite sp)
    {
        this.GetComponent<SpriteRenderer>().sprite = sp;
    }

    void Start()
    {
        colider = this.GetComponent<Collider2D>();
        ChangeSprite(noneSprite);
        colider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.GetComponent<Collider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = boxSprite;
            colider.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.B)) {
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = noneSprite;
            colider.enabled = false;
        }
        
    }
}
