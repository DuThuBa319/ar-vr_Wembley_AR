using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS12 : MonoBehaviour
{
    public GameObject contentPZG101P, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);

        contentPZG101P.SetActive(false);
    }

    public void onValueChange(int value)
    {
        contentPZG101P.SetActive(false);

        switch (value)
        {
            case 1:
                contentPZG101P.SetActive(true);
                break;
            default: break;
        }
    }

}
