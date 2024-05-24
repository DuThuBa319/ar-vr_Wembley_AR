using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS2 : MonoBehaviour
{
    public GameObject contentMR0101_1, contentMR0101_2, contentLifting, contentPZG101P, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMR0101_1.SetActive(false);
        contentPZG101P.SetActive(false);
        contentMR0101_2.SetActive(false);
        contentLifting.SetActive(false);
    }

    public void onValueChange(int value)
    {

        contentPZG101P.SetActive(false);
        contentMR0101_1.SetActive(false);
        contentLifting.SetActive(false);
        contentMR0101_2.SetActive(false);
        switch (value)
        {

            case 1:
                contentMR0101_1.SetActive(true);
                break;
            case 2:
                contentPZG101P.SetActive(true);
                break;
            case 3:
                contentMR0101_2.SetActive(true);
                break;
            case 4:
                contentLifting.SetActive(true);
                break;
            default: break;
        }
    }

}
