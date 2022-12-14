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
<<<<<<< HEAD
        string the_com1 = "COM3";
        //string the_com2 = "COM4";
        sp2 = new SerialPort(the_com1, 9600);
        //sp1 = new SerialPort(the_com2, 9600);
        /*
        if (!sp1.IsOpen)
        {
            sp1.Open();
            print("opened sp1");
        }
        */
        if (!sp2.IsOpen)
        {
            sp2.Open();
            print("opened sp2");
        }
=======
        string the_com1 = "COM5";
        string the_com2 = "COM6";
        sp1 = new SerialPort(the_com1, 9600);
        sp2 = new SerialPort(the_com2, 9600);
>>>>>>> 3463da47e87f34191710db6d206890290ab12d40
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
<<<<<<< HEAD
    }   

   
=======
    }
>>>>>>> 3463da47e87f34191710db6d206890290ab12d40

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (!sp2.IsOpen)
        {
            sp2.Open();
            print("opened sp2");
=======
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
>>>>>>> 3463da47e87f34191710db6d206890290ab12d40
        }
        string message = "";
        /*
        if (sp1.BytesToRead > 0)
        {
            message = sp1.ReadLine();
            inputString = message;
            Debug.Log(message);
        }*/
        if (sp2.BytesToRead > 0)
            {
                message = sp2.ReadLine();
                inputString = message;
                Debug.Log(message);
            }
            /*
            if (!sp1.IsOpen)
            {
                sp1.Open();
                print("opened sp1");
            }*/
            

            if (sp2.IsOpen)
            {
               CheckTiles();
            }

            }

        
    
}
