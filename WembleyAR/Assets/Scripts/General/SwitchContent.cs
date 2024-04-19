using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchContent : MonoBehaviour
{
    public GameObject overviewSwitchOn, overviewSwitchOff, detailSwitchOn, detailSwitchOff;
    public GameObject overviewContent, detailContent;
    void Start()
    {
        overviewSwitchOn.SetActive(true);
        overviewSwitchOff.SetActive(false);
        overviewContent.SetActive(true);
        detailSwitchOn.SetActive(false);
        detailSwitchOff.SetActive(true);
        detailContent.SetActive(false);
    }
    public void ShowDetailContent()
    {
        overviewSwitchOn.SetActive(false);
        overviewSwitchOff.SetActive(true);
        overviewContent.SetActive(false);
        detailSwitchOn.SetActive(true);
        detailSwitchOff.SetActive(false);
        detailContent.SetActive(true);
    }
    public void ShowOverviewContent()
    {
        overviewSwitchOn.SetActive(true);
        overviewSwitchOff.SetActive(false);
        overviewContent.SetActive(true);
        detailSwitchOn.SetActive(false);
        detailSwitchOff.SetActive(true);
        detailContent.SetActive(false);
    }
}
