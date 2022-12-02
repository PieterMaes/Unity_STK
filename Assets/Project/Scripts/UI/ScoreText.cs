using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to update UI

public class ScoreText : MonoBehaviour
{
    private int score;

    // public int Score{
    //     get { return score; }
    //     set
    //     {
    //         //when called by prefabs of cats etc., sets value of score to value+score 
    //         score = value;
    //         this.GetComponent<Text>().text = "Score: " + score ;
    //     }
    //
    // }

    // Start is called before the first frame update
    void Start()
    {
        // Score = 0;

    }

    public void SetScore(int get_score)
    {
        score += get_score;
        this.GetComponent<Text>().text = "Score: " + score;

    }

    public int GetScore()
    {
        return score;
    }

    void Update()
    {

    }
}
