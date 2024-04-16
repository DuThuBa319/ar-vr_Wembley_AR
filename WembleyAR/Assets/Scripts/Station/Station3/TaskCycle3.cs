using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskCycle3 : MonoBehaviour
{
    public GameObject frameOn, frameOff;
    public GameObject sliderBar;
    float minValue, maxValue, currentValue;
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
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = GlobalVariable.encoderPosition;
        if ((currentValue >= 950) || (currentValue > 0 && currentValue < 120))
        {
            sliderBar.GetComponent<Slider>().value = minValue;
            frameOn.SetActive(false);
            frameOff.SetActive(true);
            isOn = false;
        }
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
            if ((GlobalVariable.outputStation3[conditionIndex] == true || isOn == true) && currentValue >= minValue && currentValue < maxValue)
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