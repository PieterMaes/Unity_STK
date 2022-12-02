using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDetection : MonoBehaviour
{
    public GameObject fireCat;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LavaOrb"))
        {
            GameObject death = Instantiate(fireCat) as GameObject;
            death.transform.position = transform.position;
            Debug.Log("Cat has died");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Destroy(death.gameObject, 1.0f);
        }
    }

}
