using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDataStation12 : MonoBehaviour
{
    public int initIndex;
    public GameObject[] dataCheck;
    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < 4; i++)
        {
            if (GlobalVariable.inputStation12[i + initIndex]) dataCheck[i].SetActive(true);
            else dataCheck[i].SetActive(false);
        }
    }
}
