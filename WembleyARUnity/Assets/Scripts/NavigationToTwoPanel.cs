using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationToTwoPanel : MonoBehaviour
{
    public GameObject initialScreen, destinationScreen_1, destinationScreen_2;
    void Start()
    {
        initialScreen.SetActive(true);
        destinationScreen_1.SetActive(false);
        destinationScreen_2.SetActive(false);
    }

    public void NavigateToScreen_1()
    {
        initialScreen.SetActive(false);
        destinationScreen_1.SetActive(true);
    }
    public void NavigateToScreen_2()
    {
        initialScreen.SetActive(false);
        destinationScreen_2.SetActive(true);
    }
    public void NavigatePop()
    {
        initialScreen.SetActive(true);
        destinationScreen_1.SetActive(false);
        destinationScreen_2.SetActive(false);
    }
}
