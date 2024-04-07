using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchContent : MonoBehaviour
{
    public GameObject generalSwitchOn, generalSwitchOff, detailSwitchOn, detailSwitchOff;
    public GameObject generalContent, detailContent;
    void Start()
    {
        generalSwitchOn.SetActive(true);
        generalSwitchOff.SetActive(false);
        generalContent.SetActive(true);
        detailSwitchOn.SetActive(false);
        detailSwitchOff.SetActive(true);
        detailContent.SetActive(false);
    }
    public void ShowDetailContent()
    {
        generalSwitchOn.SetActive(false);
        generalSwitchOff.SetActive(true);
        generalContent.SetActive(false);
        detailSwitchOn.SetActive(true);
        detailSwitchOff.SetActive(false);
        detailContent.SetActive(true);
    }
    public void ShowGeneralContent()
    {
        generalSwitchOn.SetActive(true);
        generalSwitchOff.SetActive(false);
        generalContent.SetActive(true);
        detailSwitchOn.SetActive(false);
        detailSwitchOff.SetActive(true);
        detailContent.SetActive(false);
    }
}
