using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject hrtext;

    void updateInterval(float newInterval) {
        interval = newInterval;
    }

    // Start is called before the first frame update
    void Start()
    {
        stext = GameObject.Find("ScoreText");
        hrtext = GameObject.Find("HR");

        InvokeRepeating("Spawn", interval, interval);
        Debug.Log(hyperateObj.hr);
    }

    private void Spawn()
    {
        ScoreText st = stext.transform.GetComponent<ScoreText>();
        float newHR = hyperateObj.hr;
        Debug.Log("New HR:" + newHR + this.interval);

        if (newHR > 100f) {
            this.interval = 5;
            CancelInvoke();
           // GetComponent<HR>().color = Color.red;
            InvokeRepeating("Spawn", interval, interval);
        }
        if (newHR <= 100f)
        {
            this.interval = 10;
            CancelInvoke();
            //GetComponent<HR>().color = Color.yellow;
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

    void Update() {
        Debug.Log(hyperateObj.hr);
    }
}
