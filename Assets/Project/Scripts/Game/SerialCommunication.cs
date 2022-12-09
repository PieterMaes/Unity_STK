using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialCommunication : MonoBehaviour
{
    
    SerialPort sp;
    float next_time; int ii = 0;
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
            string message = "";
            try
            {
                if (sp.BytesToRead > 0)
                {
                    message = port.ReadLine();
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
    
}
