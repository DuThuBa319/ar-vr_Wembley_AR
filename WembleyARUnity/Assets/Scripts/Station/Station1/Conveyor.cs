using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject frameOn, frameOff;
    void Start()
    {
        frameOn.SetActive(false);
        frameOff.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (GlobalVariable.outputStation1[32])
        {
            frameOn.SetActive(true);
            frameOff.SetActive(false);
        }
        if (GlobalVariable.outputStation1[32] == false)
        {
            frameOn.SetActive(false);
            frameOff.SetActive(true);
        }
    }
}
