using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class SignalRData : MonoBehaviour
{


    void Start()
    {
        StartConnectWebApi();
    }

    void OnDestroy()
    {
        GlobalVariable.hubConnection.InvokeAsync("UpdateTopics", new List<string>() { });
        GlobalVariable.hubConnection.StopAsync();

    }

    void StartConnectWebApi()
    {
        GlobalVariable.hubConnection = new HubConnectionBuilder().WithUrl(GlobalVariable.url).WithAutomaticReconnect().Build();
        GlobalVariable.hubConnection.ServerTimeout = TimeSpan.FromSeconds(10);
        try
        {

            GlobalVariable.hubConnection.On<string>("OnTagChanged", (str) =>
            {
                Debug.Log("$$" + str);
                DataSignalR data = JsonConvert.DeserializeObject<DataSignalR>(str);
                if (data != null)
                {

                    UpdateData(data, str);
                }
            });
            GlobalVariable.hubConnection.On<string>("LogInfoMessage", (str) =>
            {
                Debug.Log(str);
                if (str.Contains("Connected"))
                {
                    UpdateTopics(GlobalVariable.subscribedTopics);
                }
            });

            GlobalVariable.hubConnection.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("There was an error opening the connection:" + task.Exception.GetBaseException());
                }
                else
                {
                    Debug.Log("Connected");
                }
            });

            //   await GlobalVariable.hubConnection.InvokeAsync("UpdateTopics", new List<string>() { $"{basedTopic}/" });
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }

    public void UpdateTopics(List<string> topics)
    {

        GlobalVariable.hubConnection.InvokeAsync("UpdateTopics", topics);
    }
    void UpdateData(DataSignalR data, string msg)
    {
        if (data.StationId == "IE-F2-HCA01" && data.LineId == "HerapinCap")
        {
            if (data.TagId.Contains("/"))
            {
                //! S1
                if (data.TagId.Contains("S1/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    GlobalVariable.inputStation1[index] = data.TagValue == "1" ? true : false;

                }
                else if (data.TagId.Contains("S1/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.outputStation1[index] = data.TagValue == "1" ? true : false;
                }
                //! S2
                else if (data.TagId.Contains("S2/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    GlobalVariable.inputStation2[index] = data.TagValue == "1" ? true : false;

                }
                else if (data.TagId.Contains("S2/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.outputStation2[index] = data.TagValue == "1" ? true : false;
                }
                //! S3
                else if (data.TagId.Contains("S3/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    GlobalVariable.inputStation3[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S3/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.outputStation3[index] = data.TagValue == "1" ? true : false;
                }
                //! S4
                else if (data.TagId.Contains("S4/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    GlobalVariable.inputStation4[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S4/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.outputStation4[index] = data.TagValue == "1" ? true : false;
                }
                //! S5
                else if (data.TagId.Contains("S5/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    GlobalVariable.inputStation5[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S5/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.outputStation5[index] = data.TagValue == "1" ? true : false;
                }
                //! S6
                else if (data.TagId.Contains("S6/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    GlobalVariable.inputStation6[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S6/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.outputStation6[index] = data.TagValue == "1" ? true : false;
                }
                //! S7
                else if (data.TagId.Contains("S7/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    GlobalVariable.inputStation7[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S7/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.outputStation7[index] = data.TagValue == "1" ? true : false;
                }


                //! S10
                else if (data.TagId.Contains("S10/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.inputStation10[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S10/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    GlobalVariable.outputStation10[index] = data.TagValue == "1" ? true : false;
                }
                //! S11
                else if (data.TagId.Contains("S11/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.inputStation11[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S11/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    GlobalVariable.outputStation11[index] = data.TagValue == "1" ? true : false;
                }
                //! S12
                else if (data.TagId.Contains("S12/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    GlobalVariable.inputStation12[index] = data.TagValue == "1" ? true : false;
                }
                else if (data.TagId.Contains("S12/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    GlobalVariable.outputStation12[index] = data.TagValue == "1" ? true : false;
                }
            }
            else if (data.TagId.Contains("HEIGHT"))
            {
                if (data.TagId.Contains("S8"))
                {
                    if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR1"))
                    {
                        GlobalVariable.S8_max_1 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;
                        Debug.Log(GlobalVariable.S8_max_1);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR1"))
                    {
                        GlobalVariable.S8_min_1 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR1"))
                    {
                        GlobalVariable.S8_current_1 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR1"))
                    {
                        GlobalVariable.S8_measured_1 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;
                        Debug.Log(GlobalVariable.S8_measured_1);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR1"))
                    {
                        GlobalVariable.S8_offset_1 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR3"))
                    {
                        GlobalVariable.S8_max_3 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR3"))
                    {
                        GlobalVariable.S8_min_3 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR3"))
                    {
                        GlobalVariable.S8_current_3 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR3"))
                    {
                        GlobalVariable.S8_measured_3 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("OFF_SET_TR3"))
                    {
                        GlobalVariable.S8_offset_3 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                }
                //! S9
                else if (data.TagId.Contains("S9"))
                {
                    if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR2"))
                    {
                        GlobalVariable.S9_max_2 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR2"))
                    {
                        GlobalVariable.S9_min_2 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR2"))
                    {
                        GlobalVariable.S9_current_2 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR2"))
                    {
                        GlobalVariable.S9_measured_2 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("OFF_SET_TR2"))
                    {
                        GlobalVariable.S9_offset_2 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR4"))
                    {
                        GlobalVariable.S9_max_4 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR4"))
                    {
                        GlobalVariable.S9_min_4 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR4"))
                    {
                        GlobalVariable.S9_current_4 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR4"))
                    {
                        GlobalVariable.S9_measured_4 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                    else if (data.TagId.Contains("OFF_SET_TR4"))
                    {
                        GlobalVariable.S9_offset_4 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;

                    }
                }
            }
            else
            {
                switch (data.TagId)
                {
                    case "Encoder Value":
                        GlobalVariable.encoderPosition = int.Parse(data.TagValue);
                        break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    // case "productCount":
                    //     GlobalVariable.encoderPosition = Convert.ToInt32(data.TagValue);
                    //     break;
                    default:
                        break;
                }
            }

        }





    }
}

