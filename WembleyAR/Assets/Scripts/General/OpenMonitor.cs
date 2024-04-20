using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class OpenMonitor : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject overviewMonitor, connectionMonitor, alarmMonitor;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.Hidden;
        ApplicationChrome.statusBarColor = 0x00000000;//transparent
        ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        overviewMonitor.SetActive(false);
        connectionMonitor.SetActive(false);
        alarmMonitor.SetActive(false);
        menu.SetActive(true);
        // ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
    }
    public void openOverviewMonitor()
    {
        openMonitor(overviewMonitor, true);
    }
    public void closeOverviewMonitor()
    {
        closeMonitor(overviewMonitor);
    }
    public void openConnectionMonitor()
    {
        openMonitor(connectionMonitor, false);
    }
    public void closeConnectionMonitor()
    {
        closeMonitor(connectionMonitor);
    }
    public void openAlarmMonitor()
    {
        openMonitor(alarmMonitor, true);
    }
    public void closeAlarmMonitor()
    {
        closeMonitor(alarmMonitor);
    }

    void openMonitor(GameObject targetMonitor, bool disableCamera)
    {
        menu.SetActive(false);
        targetMonitor.SetActive(true);
        if (disableCamera)
        {
            ARCamera.GetComponent<VuforiaBehaviour>().enabled = false;
            GlobalVariable.isCameraEnabled = false;
        }
        ApplicationChrome.statusBarState = ApplicationChrome.States.Visible;

    }
    void closeMonitor(GameObject targetMonitor)
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.Hidden;
        ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
        GlobalVariable.isCameraEnabled = true;
        targetMonitor.SetActive(false);
        menu.SetActive(true);
    }

}
