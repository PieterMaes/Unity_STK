using UnityEngine;
using System;
using System.IO.Ports;

public class SerialCommunication : MonoBehaviour
{
    
    SerialPort sp;
    float next_time; 
    // Use this for initialization
    void Start()
    {
        string the_com = "COM3";
        sp = new SerialPort("\\\\.\\" + the_com, 9600);
    }

    // Update is called once per frame
    void Update()
    {
            if (!sp.IsOpen)
            {
                sp.Open();
                print("opened sp");
            }

        if (sp.IsOpen)
        {
            ReceiveStr();
        }
    }
  string ReceiveStr() {
        string message = "";
        try
        {
            if (sp.BytesToRead > 0)
            {
                message = sp.ReadLine();
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
}
