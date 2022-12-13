using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string inputString;
    public GameObject tile;
    public int readPin;
    bool hardTrue = true;
    SerialPort sp;
    float next_time;
    // Start is called before the first frame update

    void Start()
    {
        string the_com = "COM3";
        sp = new SerialPort(the_com, 9600);
    }

    void CheckTiles() {

        if (inputString[3] == char.Parse("S"))
        {
            hardTrue = false;
        }
        if (inputString[3] == char.Parse("H"))
        {
            hardTrue = true;
        }

        string substr = inputString.Substring(0, 3);

        tile = GameObject.Find(substr);
        tile.GetComponent<HitScript>().hitTile(hardTrue);
    }

    // Update is called once per frame
    void Update()
    {
        if (!sp.IsOpen){
            sp.Open();
            print("opened sp");
        }

        if (sp.IsOpen)
        {
            string message = "";
            if (sp.BytesToRead > 0)
            {
                message = sp.ReadLine();
                inputString = message;
                CheckTiles();
                Debug.Log(message);
            }
        }
    }
}
