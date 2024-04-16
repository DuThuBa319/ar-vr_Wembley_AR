using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakChecking : MonoBehaviour
{
    public GameObject[] passImg, errorImg;

    void Start()
    {
        for (var i = 0; i < 4; i++)
        {
            passImg[i].SetActive(false);
            errorImg[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < 4; i++)
        {
            if (GlobalVariable.outputStation10[i])
            {
                if (GlobalVariable.inputStation10[i + 2]) passImg[i].SetActive(true);
                else errorImg[i].SetActive(true);

            }
            else
            {
                passImg[i].SetActive(false);
                errorImg[i].SetActive(false);
            }

        }
    }
}
