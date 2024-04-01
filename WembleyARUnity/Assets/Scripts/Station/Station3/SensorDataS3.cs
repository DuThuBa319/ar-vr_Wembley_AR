using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDataS3 : MonoBehaviour
{
    public int initIndex;
    public GameObject[] dataCheck = new GameObject[4];
    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < 4; i++)
        {
            if (GlobalVariable.inputStation3[i + initIndex]) dataCheck[i].SetActive(true);
            else dataCheck[i].SetActive(false);
        }
    }
}
