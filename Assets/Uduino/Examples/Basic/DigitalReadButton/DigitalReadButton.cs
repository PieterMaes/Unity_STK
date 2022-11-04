using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using UnityEngine.SceneManagement;

public class DigitalReadButton : MonoBehaviour {

    public int button = 8;
    public GameObject Start_Button;

    int buttonValue = 0;
    int prevButtonValue = 0;

    void Start ()
    {
        UduinoManager.Instance.pinMode(button, PinMode.Input_pullup);
    }

    void Update()
    {
        buttonValue = UduinoManager.Instance.digitalRead(button);

        // In this case, we compare the current button value to the previous button value, 
        // to trigger the change only once the value change.
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0)
            {
                SceneManager.LoadScene("Game");
            }
            else if (buttonValue == 1)
            {
                
            }
            prevButtonValue = buttonValue; // Here we assign prev button value to the new value
        }

    }

}
