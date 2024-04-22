using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station10_SensorData : MonoBehaviour
{

    // public GameObject[] passImg, errorImg;
    // bool isCheck, isOn;
    // int encoderPosition;
    // void Start()
    // {
    //     isCheck = false;
    //     isOn = false;
    // }
    // // Update is called once per frame
    // void Update()
    // {
    //     encoderPosition = GlobalVariable.encoderPosition;
    //     if (encoderPosition >= 0 && encoderPosition < 150)
    //     {
    //         isCheck = false;
    //         isOn = false;
    //         for (var i = 0; i < 4; i++)
    //         {
    //             passImg[i].SetActive(false);
    //             errorImg[i].SetActive(false);
    //         }
    //     }
    //     if (isCheck == false)
    //     {
    //         if (GlobalVariable.outputStation10[0])
    //         {
    //             isOn = true;

    //         }
    //         if (isOn == true)
    //         {
    //             for (var i = 0; i < 4; i++)
    //             {

    //                 if (GlobalVariable.inputStation10[i + 2]) passImg[i].SetActive(true);
    //                 else errorImg[i].SetActive(true);
    //                 if (i == 3)
    //                 {
    //                     isCheck = true;
    //                 }

    //             }
    //         }



    //     }
    // }
}
