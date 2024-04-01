using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringPanelNavigation : MonoBehaviour
{
    public GameObject wiringPanel, datasheetPanel;
    void Start()
    {

    }

    public void navigateToWiringPanel()
    {
        wiringPanel.SetActive(true);
        datasheetPanel.SetActive(false);
    }
    public void navigatePop()
    {
        wiringPanel.SetActive(false);
        datasheetPanel.SetActive(true);
    }
}