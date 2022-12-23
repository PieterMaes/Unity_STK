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
    SerialPort sp1;
    SerialPort sp2;
    float next_time;
    // Start is called before the first frame update

    void Start()
    {
        string the_com1 = "COM4";
        string the_com2 = "COM6";
        sp1 = new SerialPort(the_com1, 9600);
        sp2 = new SerialPort(the_com2, 9600);
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
       // inputString = "AD1H";
        //CheckTiles();
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
                message = sp1.ReadLine();
                inputString = message;
                CheckTiles();
                Debug.Log(message);
            }
            
        }

        if (sp2.IsOpen)
        {
            string message = "";
            if (sp2.BytesToRead > 0)
            {
                message = sp2.ReadLine();
                inputString = message;
                CheckTiles();
                Debug.Log(message);
            }
        }
    }
}
