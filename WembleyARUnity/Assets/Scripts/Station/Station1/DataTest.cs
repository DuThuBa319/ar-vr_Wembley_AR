using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DataTest : MonoBehaviour
{
    int count = 0;
    public TMP_Text countTxt;
    public GameObject progressBar;
    Slider progressBarSlider;
    void Start()
    {
        countTxt.text = count.ToString();
        progressBarSlider = progressBar.GetComponent<Slider>();
    }

    public void addCount()
    {
        count++;
        if(count > 1000)
        {
            count = 0;
        }
        countTxt.text = count.ToString();
        progressBarSlider.value += 1;
        
    }
    public void setCount(string value)
    {
        count = int.Parse(value);
        countTxt.text = count.ToString();
        progressBarSlider.value = count;
    }

    
}
