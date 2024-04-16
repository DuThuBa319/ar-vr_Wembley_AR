using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TaskCycle2 : MonoBehaviour
{
    public GameObject frameOn, frameOff;
    public GameObject sliderBar;
    float minValue, maxValue, currentValue, offsetValue;
    public int conditionIndex;
    bool isOn;
    void Start()
    {
        frameOn.SetActive(false);
        frameOff.SetActive(true);
        currentValue = sliderBar.GetComponent<Slider>().minValue;
        sliderBar.GetComponent<Slider>().value = sliderBar.GetComponent<Slider>().minValue;
        maxValue = sliderBar.GetComponent<Slider>().maxValue;
        minValue = sliderBar.GetComponent<Slider>().minValue;
        offsetValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = GlobalVariable.encoderPosition;

        if (currentValue >= 870)
        {
            sliderBar.GetComponent<Slider>().value = minValue;
            frameOn.SetActive(false);
            frameOff.SetActive(true);
            isOn = false;
        }
        if (conditionIndex == -2) // task1
        {
            if ((GlobalVariable.outputStation2[6] == true || isOn == true) && currentValue >= minValue && currentValue <= 999)
            {
                sliderBar.GetComponent<Slider>().value = currentValue - minValue;
                frameOn.SetActive(true);
                frameOff.SetActive(false);
                if (isOn == false) isOn = true;

            }
            else if (currentValue >= 0 && currentValue <= maxValue)
            {
                sliderBar.GetComponent<Slider>().value = currentValue + offsetValue;
                frameOn.SetActive(true);
                frameOff.SetActive(false);
                if (isOn == false) isOn = true;
            }
            if (currentValue >= maxValue - offsetValue)
            {
                sliderBar.GetComponent<Slider>().value = maxValue;
                frameOn.SetActive(false);
                frameOff.SetActive(true);
                isOn = false;
            }
        }
        else
        {
            if (conditionIndex == -1)
            {
                if (currentValue >= minValue && currentValue < maxValue)
                {
                    sliderBar.GetComponent<Slider>().value = currentValue;
                    frameOn.SetActive(true);
                    frameOff.SetActive(false);
                    if (isOn == false) isOn = true;
                }
            }
            else
            {
                if ((GlobalVariable.outputStation2[conditionIndex] == true || isOn == true) && currentValue >= minValue && currentValue < maxValue)
                {
                    sliderBar.GetComponent<Slider>().value = currentValue;
                    frameOn.SetActive(true);
                    frameOff.SetActive(false);
                    if (isOn == false) isOn = true;
                }
            }
            if (isOn == true && currentValue >= maxValue)
            {
                sliderBar.GetComponent<Slider>().value = maxValue;
                frameOn.SetActive(false);
                frameOff.SetActive(true);
                isOn = false;
            }
        }

    }
}
