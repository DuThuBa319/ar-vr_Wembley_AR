using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class OpenGeneralMonitor : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject generalMonitor;
    public GameObject openButton;
    public GameObject loadingAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.Visible;
        ApplicationChrome.statusBarColor = 0x00000000;//transparent
        ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        generalMonitor.SetActive(false);
        openButton.SetActive(true);
        // ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
    }

    public void openMonitor()
    {
        openButton.SetActive(false);
        generalMonitor.SetActive(true);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = false;

    }
    public void closeMonitor()
    {
        generalMonitor.SetActive(false);
        ApplicationChrome.statusBarState = ApplicationChrome.States.Hidden;
        ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
        openButton.SetActive(true);
    }
    IEnumerator EnableCameraWithLoading()
    {
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
        // Show loading indicator
        loadingAnimator.SetActive(true);

        // yield return new WaitUntil(() => VuforiaRuntime.Instance.InitializationState == VuforiaRuntime.InitState.INITIALIZED);
        yield return new WaitForSeconds(2);
        // Hide loading indicator
        loadingAnimator.SetActive(false);
    }
}
