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

    [Header("Regression rate per increase event")]
        public float regression_rate;

    [Header("Interval at which spawn rate increases")]
        public float timeUntilSpawnRateIncrease;

    [Header("HR updater")]
        [SerializeField]
        private hyperateSocket hyperateObj;

    public GameObject stext;

    void updateInterval(float newInterval) {
        interval = newInterval;
    }

    // Start is called before the first frame update
    void Start()
    {
        stext = GameObject.Find("ScoreText");
        InvokeRepeating("Spawn", interval, interval);
       // Debug.Log(hyperateObj.hr);
    }

    private void Spawn()
    {
        ScoreText st = stext.transform.GetComponent<ScoreText>();
        if (st.GetScore() == 50)
        {
            this.interval -= 2;
            CancelInvoke();
            InvokeRepeating("Spawn", interval, interval);
        }

        else if (st.GetScore() == 150)
        {
            this.interval -= (float)1.5;
            CancelInvoke();
            InvokeRepeating("Spawn", interval, interval);
        }
        else if (st.GetScore() == 300)
        {
            this.interval *= (float)0.85;
            CancelInvoke();
            InvokeRepeating("Spawn", interval, interval);
        }
        else if (st.GetScore() == 500)
        {
            this.interval *= (float)0.9;
            CancelInvoke();
            InvokeRepeating("Spawn", interval, interval);
        }

        //add object instance at coordinates set
        float random = Random.Range(minX, maxX);
        
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(
            random, y
            );
        instance.transform.SetParent(transform);

        //change srpite of object
/*        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;*/
    }

}
