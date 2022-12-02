using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to update UI

public class ScoreText : MonoBehaviour
{
    private int score;

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
