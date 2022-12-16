using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputStart : MonoBehaviour
{
    SerialPort sp1;
    SerialPort sp2;
    // Start is called before the first frame update

    void Start()
    {
        string the_com1 = "COM4";
        string the_com2 = "COM6";
        sp1 = new SerialPort(the_com1, 9600);
        sp2 = new SerialPort(the_com2, 9600);
    }
    
    void Update()
    {
        if (!sp1.IsOpen){
            sp1.Open();
            print("opened sp");
        }
        if (!sp2.IsOpen)
        {
            sp2.Open();
            print("opened sp");
        }
        if (sp1.IsOpen)
        {
            string message = "";
            if (sp1.BytesToRead > 0)
            {
                message = "Start Game";
                Debug.Log(message);
                SceneManager.LoadScene("Game");
            }
            
        }
        if (sp2.IsOpen)
        {
            string message = "";
            if (sp2.BytesToRead > 0)
            {
                message = "Start Game";
                Debug.Log(message);
                SceneManager.LoadScene("Game");
            }
        }
    }
}
