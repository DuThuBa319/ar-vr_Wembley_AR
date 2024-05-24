using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunction : MonoBehaviour
{
    public GameObject contentMR0101, contentMK5343, contentPZG101P, contentLifting, contentGripper, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMK5343.SetActive(false);
        contentMR0101.SetActive(false);
        contentPZG101P.SetActive(false);
        contentLifting.SetActive(false);
        contentGripper.SetActive(false);
    }

    public void onValueChange(int value)
    {
        contentMK5343.SetActive(false);
        contentLifting.SetActive(false);
        contentMR0101.SetActive(false);
        contentPZG101P.SetActive(false);
        contentGripper.SetActive(false);
        switch (value)
        {
            case 2:
                contentMK5343.SetActive(true);
                break;
            case 3:
                contentMR0101.SetActive(true);
                break;
            case 1:
                contentPZG101P.SetActive(true);
                break;
            case 4:
                contentLifting.SetActive(true);
                break;
            case 5:
                contentGripper.SetActive(true);
                break;
            default: break;
        }
    }

}
