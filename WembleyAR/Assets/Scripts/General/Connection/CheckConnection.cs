using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConnection : MonoBehaviour
{
    // Start is called before the first frame update
    float waitTime = 3f;
    float timer = 0f;

    void Awake()

    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (GlobalVariable.networkConnected) GlobalVariable.networkConnected = false;

        }
        else
        {
            if (!GlobalVariable.networkConnected)
                GlobalVariable.networkConnected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                if (GlobalVariable.networkConnected) GlobalVariable.networkConnected = false;

            }
            else
            {
                if (!GlobalVariable.networkConnected)
                    GlobalVariable.networkConnected = true;
            }
            timer = 0f;
        }
    }
}
