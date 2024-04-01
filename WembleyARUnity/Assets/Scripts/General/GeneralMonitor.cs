using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;

public class GeneralMonitor : MonoBehaviour
{
    // Start is called before the first frame update
    GeneralMonitorModel generalMonitorModel = new GeneralMonitorModel();
    void Start()
    {
        // GlobalVariable.hubConnection.On<string>("TagChanged", (str) =>
        // {

        //     DataSignalR data = JsonUtility.FromJson<DataSignalR>(str);
        //     //Debug.Log(data);
        //     if (data.TagId.Contains("productCount"))
        //     {
        //         Debug.Log(data.TagValue);
        //     }
        // });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
