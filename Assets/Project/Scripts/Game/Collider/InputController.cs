using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject AA1;
    public GameObject AB1;
    public GameObject AC1;
    public GameObject AD1;

    public string inputString;
    public int readPin;
    bool hardTrue = true;
    SerialPort sp;
    float next_time;
    // Start is called before the first frame update

    void Start()
    {
        string the_com = "COM3";
        sp = new SerialPort("\\\\.\\" + the_com, 9600);
    }

    void checkTiles(string inputStr) {

        if (inputString[3] == char.Parse("S"))
        {
            hardTrue = false;
        }
        if (inputString[3] == char.Parse("H"))
        {
            hardTrue = true;
        }

        char kwadrant = inputStr[2];
        if (kwadrant == char.Parse("1"))
        {

            if (inputString == "AA1S" || inputString == "AA1H")
            {
                AA1.GetComponent<HitScript>().hitTile(hardTrue);
            }
            if (inputString == "AB1S" || inputString == "AB1H")
            {
                AB1.GetComponent<HitScript>().hitTile(hardTrue);
            }
            if (inputString == "AC1S" || inputString == "AC1H")
            {
                AC1.GetComponent<HitScript>().hitTile(hardTrue);
            }
        }
    }

    string ReceiveStr()
    {
        string message = "";
        try
        {
            if (sp.BytesToRead > 0)
            {
                message = sp.ReadLine();
                inputString = message;
            }

        }
        catch (Exception e)
        {
            // swallow read timeout exceptions
            if (e.GetType() == typeof(TimeoutException))
                return message;
            else
                throw;
        }
        return message;
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
            ReceiveStr();
        }

        inputString = "AC1H";
        checkTiles(inputString);
    }
}
