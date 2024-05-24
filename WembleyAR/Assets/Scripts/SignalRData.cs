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
    public GameObject[] inputCheckS1;
    public GameObject[] outputCheckS1;
    public GameObject[] inputCheckS2;
    public GameObject[] outputCheckS2;
    public GameObject[] inputCheckS3;
    public GameObject[] outputCheckS3;
    public GameObject[] inputCheckS4;
    public GameObject[] outputCheckS4;
    public GameObject[] inputCheckS5;
    public GameObject[] outputCheckS5;
    public GameObject[] inputCheckS6;
    public GameObject[] outputCheckS6;
    public GameObject[] inputCheckS7;
    public GameObject[] outputCheckS7;
    public GameObject[] inputCheckS10;
    public GameObject[] outputCheckS10;
    public GameObject[] inputCheckS11;
    public GameObject[] outputCheckS11;
    public GameObject[] inputCheckS12;
    public GameObject[] outputCheckS12;
    public GameObject[] S1SensorCheck;
    public GameObject[] S2SensorCheck;
    public GameObject[] S3SensorCheck;
    public GameObject[] S4SensorCheck;
    public GameObject[] S5SensorCheck;
    public GameObject[] S10SensorCheck;
    public GameObject[] S12SensorCheck;
    bool isReset;


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
            //  Debug.Log("$$" + str);
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
                GlobalVariable.hubConnection.InvokeAsync("SendAll");
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
                    GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
                    UpdateTopics(GlobalVariable.subscribedTopics);
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

    void Update()
    {
        // if (isReset && GlobalVariable.encoderPosition > 0 && GlobalVariable.encoderPosition < 100)
        // {
        //     isReset = false;
        // }
        // if (!isReset && GlobalVariable.encoderPosition > 150 && GlobalVariable.encoderPosition < 250)
        // {
        //     for (int i = 0; i < 4; i++)
        //     {
        //         S10SensorCheck[i].SetActive(false);
        //         S5SensorCheck[i].SetActive(false);
        //         S3SensorCheck[i].SetActive(false);
        //     }
        //     isReset = true;
        // }
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
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS1[index].SetActive(value);
                    if (index != 0 && index != 1) S1SensorCheck[index - 2].SetActive(value);

                }
                else if (data.TagId.Contains("S1/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS1[index].SetActive(value);
                    if (index == 12) GlobalVariable.outputStation1[12] = value;
                }
                //! S2
                else if (data.TagId.Contains("S2/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS2[index].SetActive(value);
                    if (index != 0 && index != 2) S2SensorCheck[index - 2].SetActive(value);


                }
                else if (data.TagId.Contains("S2/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS2[index].SetActive(value);
                }
                //! S3
                else if (data.TagId.Contains("S3/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS3[index].SetActive(value);
                    if (index > 0 && index < 5)
                    {
                        if (value) S3SensorCheck[index - 1].SetActive(value);
                    }
                }
                else if (data.TagId.Contains("S3/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS3[index].SetActive(value);
                }
                //! S4
                else if (data.TagId.Contains("S4/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS4[index].SetActive(value);
                    if (index != 0 && index != 1) S4SensorCheck[index - 2].SetActive(value);
                }
                else if (data.TagId.Contains("S4/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS4[index].SetActive(value);
                }
                //! S5
                else if (data.TagId.Contains("S5/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS5[index].SetActive(value);
                    if (index > 0)
                    {
                        if (value) S5SensorCheck[index - 1].SetActive(value);
                    }
                }
                else if (data.TagId.Contains("S5/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS5[index].SetActive(value);
                }
                //! S6
                else if (data.TagId.Contains("S6/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS6[index].SetActive(value);
                }
                else if (data.TagId.Contains("S6/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS6[index].SetActive(value);
                }
                //! S7
                else if (data.TagId.Contains("S7/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS7[index].SetActive(value);
                }
                else if (data.TagId.Contains("S7/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS7[index].SetActive(value);

                }


                //! S10
                else if (data.TagId.Contains("S10/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS10[index].SetActive(value);
                    if (index > 1 && index < 6)
                    {
                        if (value)
                            S10SensorCheck[index - 2].SetActive(value);
                    }
                }
                else if (data.TagId.Contains("S10/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS10[index].SetActive(value);
                }
                //! S11
                else if (data.TagId.Contains("S11/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS11[index].SetActive(value);
                }
                else if (data.TagId.Contains("S11/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS11[index].SetActive(value);
                }
                //! S12
                else if (data.TagId.Contains("S12/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS12[index].SetActive(value);
                    S12SensorCheck[index].SetActive(value);
                }
                else if (data.TagId.Contains("S12/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS12[index].SetActive(value);
                }
            }
            else if (data.TagId.Contains("HEIGHT"))
            {
                if (data.TagId.Contains("S8"))
                {
                    if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR1"))
                    {
                        GlobalVariable.S8_max_1 = JsonConvert.DeserializeObject<DoubleTypeDataModel>(msg).TagValue;


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
                        // Debug.Log(GlobalVariable.S8_measured_1);

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
                    //data.TagId.Contains("HEIGHT_CHK_REJ_TR")
                    int index = int.Parse(data.TagId.Remove(0, 17));
                    GlobalVariable.RejCountS89TR[index - 1] = int.Parse(data.TagValue);
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
                ErrorInfor errorInfor;
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
                        Debug.Log(data.TagValue);
                        errorInfor = new ErrorInfor { errorName = data.TagValue, time = data.TimeStamp.ToString("HH:mm:ss dd/MM/yyyy") };
                        GlobalVariable.errorInfors.Add(errorInfor);
                        alarmScript.gameObject.GetComponent<ErrorListView>().GenerateListView(GlobalVariable.errorInfors);
                        break;
                    case "endErrorStatus":
                        errorInfor = new ErrorInfor { errorName = data.TagValue, time = data.TimeStamp.ToString("HH:mm:ss dd/MM/yyyy") };
                        for (int i = 0; i < GlobalVariable.errorInfors.Count; i++)
                        {
                            if (GlobalVariable.errorInfors[i].errorName == errorInfor.errorName)
                            {
                                GlobalVariable.errorInfors.RemoveAt(i);
                                break;
                            }
                        }
                        alarmScript.gameObject.GetComponent<ErrorListView>().GenerateListView(GlobalVariable.errorInfors);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}

