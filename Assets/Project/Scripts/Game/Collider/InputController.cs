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
        //Debug.Log(substr);

        tile = GameObject.Find(substr);
        tile.GetComponent<HitScript>().hitTile(hardTrue);
    }

    string ReceiveStr()
    {
        string message = "";
        try
        {
            if (sp.BytesToRead > 0)
            {
                message = sp.ReadLine();
                CheckTiles();
                //inputString = "AE3H";
                Debug.Log(message);
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
    void tryCatch(string message) {
        try
        {
            if (sp.BytesToRead > 0)
            {
                message = sp.ReadLine();
                inputString = message;
                CheckTiles();
                Debug.Log(message);
            }
        }
        catch (Exception e)
        {
            Debug.Log(message);
            return;
        }
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
            tryCatch(message);
        }
    }
}
