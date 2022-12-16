using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class Wizard1 : MonoBehaviour
{
   
    private int _health;
    private bool _isDropping;

    public Wizard1()
    {
        _health = 3;
        _isDropping = false;
    }

    public int getHealth()
    {
        return _health;
    }
    public void hitWizard()
    {
        _health-= 1;
    }
    
    public void setDropping()
    {
        _isDropping = false;
    }
    
    public void OnMouseDown()
    {
        if (_isDropping) return;
        hitWizard();
        var text = GameObject.Find("ScoreText");
        text.transform.GetComponent<ScoreText>().SetScore(5);
        _isDropping = true;
    }

}