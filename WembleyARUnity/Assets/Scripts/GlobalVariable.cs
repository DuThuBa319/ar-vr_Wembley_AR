using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public static HubConnection hubConnection;
    public static string url = "https://wembleyscada.azurewebsites.net/NotificationHub";
    public static int encoderPosition = 0;
    //? Station 1
    public static bool[] inputStation1 = new bool[14];
    public static bool[] outputStation1 = new bool[33];

}
public class DataSignalR
{
    public string StationId;
    public string LineId;
    public string TagId;
    public string TagValue;
    public string TimeStamp;
}

public class GeneralMonitorModel
{
    public int totalCount;
}
