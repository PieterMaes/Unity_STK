using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class InputController : MonoBehaviour
{
    public GameObject AA1;
    public GameObject AB1;
    public GameObject AC1;
    public GameObject AD1;

    public string inputString;
    public int readPin;
    bool hardTrue = true;
// Start is called before the first frame update
void Start()
    {
        UduinoManager.Instance.pinMode(readPin, PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        //  inputString = UduinoManager.Instance.analogRead(readPin, inputString);
        inputString = "AC1H";

        if (inputString[3] == char.Parse("S")) {
            hardTrue = false;
        }
        if (inputString[3] == char.Parse("H"))
        {
            hardTrue = true;
        }

        char kwadrant = inputString[2];
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
            if (inputString == "AC1S"|| inputString == "AC1H")
            {
                AC1.GetComponent<HitScript>().hitTile(hardTrue);
            }
        }
    }
}
