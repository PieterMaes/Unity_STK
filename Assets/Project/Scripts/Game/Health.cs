using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberOfHearths;

    public Image[] hearths;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    private void Update()
    {
        if (health > numberOfHearths)
        {
            health = numberOfHearths;
        }
        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < health)
            {
                hearths[i].sprite = fullHearth;
            }
            else
            {
                hearths[i].sprite = emptyHearth;
            }
            if (i < numberOfHearths)
            {
                hearths[i].enabled = true;
            }
            else
            {
                hearths[i].enabled = false;
            }
        }
    }
}
