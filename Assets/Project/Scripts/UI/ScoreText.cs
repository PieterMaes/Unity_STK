using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to update UI

public class ScoreText : MonoBehaviour
{
    private int score;

    public int Score{
        get { return score; }
        set
        {
            //when called by prefabs of cats etc., sets value of score to value+score 
            score = value;
            GetComponent<Text>().text = "Score: " + score;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }
    
    void Update()
    {

    }
}
