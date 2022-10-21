using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("Speed Variables")]
    public float min_XSpeed; 
    public float max_XSpeed, min_YSpeed, max_YSpeed;
    
    [Header("Gameplay Variables")]
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        //throw move object upwards
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            Random.Range(min_XSpeed, max_XSpeed), 
            Random.Range(min_YSpeed, max_YSpeed)
        );
        //wait and destroy
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
