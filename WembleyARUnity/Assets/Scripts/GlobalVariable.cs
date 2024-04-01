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
     //? Station 3
    public static bool[] inputStation3 = new bool[9];
    public static bool[] outputStation3 = new bool[10];
    //? Station 5
    public static bool[] inputStation5 = new bool[5];
    public static bool[] outputStation5 = new bool[2];

    //? Station 6
    public static bool[] inputStation6 = new bool[6];
    public static bool[] outputStation6 = new bool[6];
    //? Station 7
    public static bool[] inputStation7 = new bool[7];
    public static bool[] outputStation7 = new bool[6];
      //? Station 10
    public static bool[] inputStation10 = new bool[8];
    public static bool[] outputStation10 = new bool[4];
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
