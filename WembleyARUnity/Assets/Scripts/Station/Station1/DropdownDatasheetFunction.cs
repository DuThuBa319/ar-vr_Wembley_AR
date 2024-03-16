using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownDatasheetFunction : MonoBehaviour
{
    public GameObject contentMMR0101, contentMK5343;
    // Start is called before the first frame update
    void Start()
    {
       contentMK5343.SetActive(false);
       contentMMR0101.SetActive(false);
    }

    public void onValueChange(int value)
    {
        if(value == 0)
        {
            contentMK5343.SetActive(false);
            contentMMR0101.SetActive(false);
        }
        else if(value ==1){
            contentMK5343.SetActive(true);
            contentMMR0101.SetActive(false);
        }
        else if(value == 2)
        {
            contentMK5343.SetActive(false);
            contentMMR0101.SetActive(true);
        }
    }
    
}
