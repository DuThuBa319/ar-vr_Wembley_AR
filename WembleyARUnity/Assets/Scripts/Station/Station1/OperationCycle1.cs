using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OperationCycle1 : MonoBehaviour
{
    public TMP_Text encoderPositionText;
    
    public GameObject frameOn, frameOff;
    public GameObject sliderBar;
    float minValue, maxValue, currentValue;
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
    {          encoderPositionText.text = GlobalVariable.encoderPosition.ToString();

        currentValue = GlobalVariable.encoderPosition;
        if ((currentValue >= 990) || (currentValue > 0 && currentValue < 20))
        {
            sliderBar.GetComponent<Slider>().value = minValue;
            frameOn.SetActive(false);
            frameOff.SetActive(true);
        }
        if (currentValue >= minValue && currentValue < maxValue)
        {
            sliderBar.GetComponent<Slider>().value = currentValue;
            frameOn.SetActive(true);
            frameOff.SetActive(false);
        }
        if (currentValue >= maxValue)
        {
            sliderBar.GetComponent<Slider>().value = maxValue;
            frameOn.SetActive(false);
            frameOff.SetActive(true);
        }
    }
  

    // Update is called once per frame
    
}
