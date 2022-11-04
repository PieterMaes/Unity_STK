using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using UnityEngine.SceneManagement;

public class HitHardSoft : MonoBehaviour
{

    public int buttonHard = 8; //hit hard
    public int buttonSoft = 9;

    public GameObject testCircle;

    int buttonValueHard = 0;
    //int prevButtonValueHard = 0;

    int buttonValueSoft = 0;
    //int prevButtonValueSoft = 0;

    void Start()
    {
        UduinoManager.Instance.pinMode(buttonHard, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(buttonSoft, PinMode.Input_pullup);
    }

    void Update()
    {
        buttonValueHard = UduinoManager.Instance.digitalRead(buttonHard);
        buttonValueSoft = UduinoManager.Instance.digitalRead(buttonSoft);

        // In this case, we compare the current button value to the previous button value, 
        // to trigger the change only once the value change.
        if (buttonValueHard == 0) {
            testCircle.GetComponent<Renderer>().material.color = Color.red;
        }
        if(buttonValueSoft == 0)
        {
            testCircle.GetComponent<Renderer>().material.color = Color.green;
            ;
        }

    }
    /*
    void PressedDown()
    {
        buttonGameObject.GetComponent<Renderer>().material.color = Color.red;
        buttonGameObject.transform.Translate(Vector3.down / 20);
    }

    void PressedUp()
    {
        buttonGameObject.GetComponent<Renderer>().material.color = Color.green;
        buttonGameObject.transform.Translate(Vector3.up / 20);
    }
    */

}
