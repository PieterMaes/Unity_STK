using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header ("Target")]
        public GameObject prefab;

    [Header ("Gameplay")]
        public float interval;
        public float minX;
        public float maxX;
        public float y;

    [Header ("Visuals")]
        public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", interval, interval);
    }

    // Update is called once per frame
    private void Spawn()
    {
        //add object instance at coordinates set
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(
            Random.Range(minX, maxX), y
            );

        //change srpite of object
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
