using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraController : MonoBehaviour
{
    private bool isCameraEnabled = true; // Default to true, assuming the camera starts enabled
    public Camera ARCamera;
    void Start()
    {

    }

    void OnApplicationFocus(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // If the app is being paused (e.g., turning off the phone), save the camera state
            SaveCameraState();

        }
        else
        {
            isCameraEnabled = PlayerPrefs.GetInt("CameraEnabled", 1) == 1;
            ARCamera.GetComponent<VuforiaBehaviour>().enabled = isCameraEnabled;
        }
    }
    // void OnApplicationFocus(bool hasFocus)
    // {

    // }

    private void SaveCameraState()
    {
        // Save the camera state using PlayerPrefs
        PlayerPrefs.SetInt("CameraEnabled", isCameraEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }


}