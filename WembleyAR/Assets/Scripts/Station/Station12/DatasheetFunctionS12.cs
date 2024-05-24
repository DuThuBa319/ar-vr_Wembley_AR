using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS12 : MonoBehaviour
{
    public GameObject contentPZG101P, contentMK5343, contentGripperS11, contentGripperS12, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMK5343.SetActive(false);
        contentPZG101P.SetActive(false);
        contentGripperS11.SetActive(false);
        contentGripperS12.SetActive(false);
    }

    public void onValueChange(int value)
    {
        contentPZG101P.SetActive(false);
        contentMK5343.SetActive(false);
        contentGripperS11.SetActive(false);
        contentGripperS12.SetActive(false);
        switch (value)
        {
            case 1:
                contentPZG101P.SetActive(true);
                break;
            case 2:
                contentMK5343.SetActive(true);
                break;
            case 3:
                contentGripperS11.SetActive(true);

                break;
            case 4:

                contentGripperS12.SetActive(true);
                break;
            default: break;
        }
    }

}
