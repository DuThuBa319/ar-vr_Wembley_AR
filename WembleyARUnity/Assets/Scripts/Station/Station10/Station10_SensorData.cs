using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station10_SensorData : MonoBehaviour
{
    public int initIndex;
    public GameObject[] dataCheck;
    bool isCheck;
    int encoderPosition;
    void Start()
    {
        isCheck = false;
    }
    // Update is called once per frame
    void Update()
    {
        encoderPosition = GlobalVariable.encoderPosition;
        if (encoderPosition >= 0 && encoderPosition < 150)
        {
            isCheck = false;
            for (var i = 0; i < 4; i++)
            {
                dataCheck[i].SetActive(false);
            }
        }
        if (isCheck == false)
        {
            for (var i = 0; i < 4; i++)
            {

                if (GlobalVariable.inputStation10[i + initIndex])
                {
                    dataCheck[i].SetActive(true);
                    isCheck = true;
                }
            }

        }
    }
}
