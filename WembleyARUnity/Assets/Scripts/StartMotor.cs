using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMotor : MonoBehaviour
{
    public GameObject motorImg;
    public Sprite motorOn, motorOff;
    void Start()
    {
        motorImg.GetComponent<Image>().sprite=motorOff;
        
    }
    public void onStartBtnClick()
    {
        motorImg.GetComponent<Image>().sprite = motorOn;
    }
    public void onStopBtnClick()
    {
        motorImg.GetComponent<Image>().sprite = motorOff;
    }

}
