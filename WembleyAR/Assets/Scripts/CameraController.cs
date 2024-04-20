using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraController : MonoBehaviour
{
    private bool isCameraEnabled = true; // Default to true, assuming the camera starts enabled


    void Start()
    {
        transform.GetComponent<VuforiaBehaviour>().enabled = true;
        GlobalVariable.isCameraEnabled = true;
    }

    private void OnApplicationFocus(bool focusStatus)
    {

        if (focusStatus)
        {
            transform.GetComponent<VuforiaBehaviour>().enabled = GlobalVariable.isCameraEnabled;
        }

        // if (focusStatus)
        // {
        //     isCameraEnabled = PlayerPrefs.GetInt("CameraEnabled", 1) == 1;
        //     ARCamera.GetComponent<VuforiaBehaviour>().enabled = isCameraEnabled;
        // }
        // else
        // {
        //     // Store the camera status
        //     isCameraEnabled = ARCamera.GetComponent<VuforiaBehaviour>().enabled;
        //     PlayerPrefs.SetInt("CameraEnabled", isCameraEnabled ? 1 : 0);
        //     PlayerPrefs.Save();
        // }
    }
}