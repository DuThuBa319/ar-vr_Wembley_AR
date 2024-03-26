using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavFromSheetToWire : MonoBehaviour
{
    public GameObject wiringMR0101, wiringMK5343, wiringDWAS603M8;
    public GameObject currentSheet;

    // Start is called before the first frame update
    void Start()
    {   currentSheet.SetActive(true);
        wiringMR0101.SetActive(false);
        wiringMK5343.SetActive(false);
        wiringDWAS603M8.SetActive(false);
    }
    public void navigateToWiringMR0101()
    {
      
       currentSheet.SetActive(false);
       
       wiringMR0101.SetActive(true);
    }
    public void navigateToWiringMK5343()
    {
        currentSheet.SetActive(false);
       
        wiringMK5343.SetActive(true);
    }
    public void navigateToWiringDWAS603M8()
    {
       currentSheet.SetActive(false);
       
       wiringDWAS603M8.SetActive(true);
    }
   
    public void navigatorPop()
    {
      
    {
       currentSheet.SetActive(true);
    
       wiringMR0101.SetActive(false);
        wiringMK5343.SetActive(false);
        wiringDWAS603M8.SetActive(false);
    }  
   
    }
}
