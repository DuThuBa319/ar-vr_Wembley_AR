using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
public class SignalRData : MonoBehaviour
{
    public GameObject alarmScript;


    void Start()
    {

        StartConnectWebApi();
    }

    void OnDestroy()
    {
        GlobalVariable.hubConnection.InvokeAsync("UpdateTopics", new List<string>() { });
        GlobalVariable.hubConnection.StopAsync();

    }

    private async void StartConnectWebApi()
    {

        if (GlobalVariable.hubConnection == null)
        {
            // Tạo kết nối
            GlobalVariable.hubConnection = GlobalVariable.hubConnection = new HubConnectionBuilder().WithUrl(GlobalVariable.url)
                .WithAutomaticReconnect()
                .Build();
        }


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
            if (str.Contains("Connected"))
            {
                UpdateTopics(GlobalVariable.subscribedTopics);
                GlobalVariable.isConnecting = false;
                GlobalVariable.serverConnected = true;
            }
        });
        GlobalVariable.isConnecting = true;
        try
        {
            await GlobalVariable.hubConnection.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("There was an error opening the GlobalVariable.hubConnection:" + task.Exception.GetBaseException());
                    GlobalVariable.errorServerConnected = true;
                    GlobalVariable.isConnecting = false;
                }
                if (task.IsCompletedSuccessfully)
                {
                    GlobalVariable.isConnecting = false;
                    GlobalVariable.serverConnected = true;
                }

            });
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
        GlobalVariable.hubConnection.Reconnecting += (exception) =>
            {

                if (exception != null)
                {
                    Debug.Log("There was an error opening the GlobalVariable.hubConnection:" + exception.GetBaseException());
                    GlobalVariable.errorServerConnected = true;
                    GlobalVariable.isConnecting = false;
                }

                GlobalVariable.isConnecting = true;
                return Task.CompletedTask;
            };

        GlobalVariable.hubConnection.Reconnected += (ConnectionId) =>
        {
            GlobalVariable.isConnecting = false;
            GlobalVariable.serverConnected = true;
            return Task.CompletedTask;
        };


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
                else if (data.TagId.Contains("REJ"))
                {
                    if (data.TagId.Contains("TR1"))
                    {
                        GlobalVariable.RejCountS89TR[0] = int.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TR2"))
                    {
                        GlobalVariable.RejCountS89TR[1] = int.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TR3"))
                    {
                        GlobalVariable.RejCountS89TR[2] = int.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TR4"))
                    {
                        GlobalVariable.RejCountS89TR[3] = int.Parse(data.TagValue);
                    }
                }
            }
            else if (data.TagId.Contains("GOOD_CNT_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 11));
                GlobalVariable.goodProductCountTR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("BAD_CNT_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 10));
                GlobalVariable.badProductCountTR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("TOTAL_CNT_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 12));
                GlobalVariable.productCountTR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("BOTTOM_CAP_REJ_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 17));
                GlobalVariable.RejCountS1TR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("SILICON_PRESENCE_REJ_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 23));
                GlobalVariable.RejCountS3TR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("COVER_PRESENCE_REJ_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 21));
                GlobalVariable.RejCountS5TR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("HEIGHT_CHK_REJ_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 17));
                GlobalVariable.RejCountS89TR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("LEAK_TEST_CHK_TR"))
            {
                int index = int.Parse(data.TagId.Remove(0, 16));
                GlobalVariable.RejCountS10TR[index - 1] = int.Parse(data.TagValue);
            }
            else if (data.TagId.Contains("LEAK_TEST_CHK_OK_TR1"))
            {
                GlobalVariable.RejCountS10TR[0] = int.Parse(data.TagValue);
            }
            else
            {
                switch (data.TagId)
                {
                    case "Encoder Value":
                        GlobalVariable.encoderPosition = int.Parse(data.TagValue);
                        break;
                    case "productCount":
                        GlobalVariable.productCount = int.Parse(data.TagValue);
                        break;
                    case "goodProductRaw":
                        GlobalVariable.goodProductCount = int.Parse(data.TagValue);
                        break;
                    case "errorProduct":
                        GlobalVariable.badProductCount = int.Parse(data.TagValue);
                        break;
                    case "EFF":
                        GlobalVariable.effective = double.Parse(data.TagValue);
                        break;
                    case "operationTimeRaw":
                        GlobalVariable.operationTime = data.TagValue;
                        break;
                    case "errorStatus":
                        ErrorInfor errorInfor = new ErrorInfor { errorName = data.TagValue, time = data.TimeStamp.ToString("HH:mm:ss dd/MM/yyyy") };
                        GlobalVariable.errorInfors.Add(errorInfor);
                        alarmScript.gameObject.GetComponent<ErrorListView>().GenerateListView(GlobalVariable.errorInfors);
                        break;
                    default:
                        break;
                }
            }

        }





    }
}

