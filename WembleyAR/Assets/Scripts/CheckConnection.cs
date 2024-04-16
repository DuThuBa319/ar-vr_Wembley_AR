using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConnection : MonoBehaviour
{
    // Start is called before the first frame update
    float waitTime = 3f;

    float timer = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                // Debug.Log("No internet access");
            }
            else
            {
                //Debug.Log("internet connection");
            }
            timer = 0f;
        }
    }
}
