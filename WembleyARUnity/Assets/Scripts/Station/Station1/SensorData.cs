using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorData : MonoBehaviour
{
    public GameObject[] dataCheck = new GameObject[4];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       for (var i = 0; i < GlobalVariable.inputStation1.Length; i++)
        {
            if (GlobalVariable.inputStation1[i]) dataCheck[i].SetActive(true);
            else dataCheck[i].SetActive(false);
        } 
    }
}
