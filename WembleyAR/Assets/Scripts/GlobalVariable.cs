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
    public static string basedTopic = "Wembley/HerapinCap/IE-F2-HCA01";
    public static List<string> subscribedTopics = new List<string>();
    public static int encoderPosition = 0;
    //? Station 1
    public static bool[] inputStation1 = new bool[14];
    public static bool[] outputStation1 = new bool[19];
    //? Station 2
    public static bool[] inputStation2 = new bool[6];
    public static bool[] outputStation2 = new bool[19];
    //? Station 3
    public static bool[] inputStation3 = new bool[9];
    public static bool[] outputStation3 = new bool[10];
    //? Station 4
    public static bool[] inputStation4 = new bool[10];
    public static bool[] outputStation4 = new bool[24];
    //? Station 5
    public static bool[] inputStation5 = new bool[5];
    public static bool[] outputStation5 = new bool[2];

    //? Station 6
    public static bool[] inputStation6 = new bool[7];
    public static bool[] outputStation6 = new bool[9];
    //? Station 7
    public static bool[] inputStation7 = new bool[7];
    public static bool[] outputStation7 = new bool[7];

    //? Station 8
    //! TR1
    public static double S8_max_1 = 21.32;
    public static double S8_min_1 = 21.00;
    public static double S8_offset_1 = 20.95;
    public static double S8_current_1 = 0.29;
    public static double S8_measured_1 = 21.24;
    //! TR3
    public static double S8_max_3 = 21.32;
    public static double S8_min_3 = 21.00;
    public static double S8_offset_3 = 20.95;
    public static double S8_current_3 = 0.29;
    public static double S8_measured_3 = 21.24;
    //? S9
    //! TR2
    //! TR3
    public static double S9_max_2 = 21.32;
    public static double S9_min_2 = 21.00;
    public static double S9_offset_2 = 20.95;
    public static double S9_current_2 = 0.29;
    public static double S9_measured_2 = 21.24;
    //! TR3
    public static double S9_max_4 = 21.32;
    public static double S9_min_4 = 21.00;
    public static double S9_offset_4 = 20.95;
    public static double S9_current_4 = 0.29;
    public static double S9_measured_4 = 21.4;
    //? Station 10
    public static bool[] inputStation10 = new bool[8];
    public static bool[] outputStation10 = new bool[12];
    //? Station 11
    public static bool[] inputStation11 = new bool[1];
    public static bool[] outputStation11 = new bool[10];
    //? Station 12
    public static bool[] inputStation12 = new bool[4];
    public static bool[] outputStation12 = new bool[2];
}
[System.Serializable]
public class DataSignalR
{
    public string StationId;
    public string LineId;
    public string TagId;
    public string TagValue;
    public string TimeStamp;
}
[System.Serializable]
public class DoubleTypeDataModel
{
    public string StationId;
    public string LineId;
    public string TagId;
    public double TagValue;
    public string TimeStamp;
}


[System.Serializable]
public class ManufacturingInfo
{
    public string productName;
    public string referenceId;
    public string referenceName;

    public string lotCode;
    public int lotSize;
    public Line line;
    public StationInfo[] stations;
}
[System.Serializable]
public class Line
{
    public string lineId;
    public string lineName;
    public int lineType;
}
[System.Serializable]
public class StationInfo
{
    public string stationId;
    public EmployeeInfo[] employees;
    public Mfc[] mfCs;
}
[System.Serializable]
public class EmployeeInfo
{
    public string employeeId;
    public string employeeName;
}
[System.Serializable]
public class Mfc
{
    public string mfcName;
    public int value;
    public int minValue;
    public int maxValue;
}
[System.Serializable]
public class Wrapper
{
    public ManufacturingInfo[] manufacturingData;
}