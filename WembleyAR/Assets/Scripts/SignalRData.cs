using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using System.Linq;
using System.Diagnostics.Tracing;
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
    //public GameObject[] S1SensorCheck;


    public GameObject[] S3SensorCheck_2;

    // public GameObject[] S5SensorCheck_1;
    public GameObject[] S5SensorCheck_2;
    public GameObject[] S10SensorCheck;

    //? S1
    public GameObject S1_Horz_Snr_On, S1_Horz_Snr_Off, S1_Vert_Up, S1_Vert_Dn, S1_Horz_Fwd, S1_Horz_Rev, S1_Gripper_On, S1_Gripper_Off;
    public GameObject[] S1_SensorCheck;
    //? S2
    public GameObject S2_Horz_Snr_On, S2_Horz_Snr_Off, S2_Vert_Up, S2_Vert_Dn, S2_Horz_Fwd, S2_Horz_Rev, S2_Vacuum_On, S2_Vacuum_Off;
    // GameObject[] S2SensorCheck;
    public GameObject[] S2_GripperOn;
    bool isReset;
    //? S3
    public GameObject[] S3_Press_Dn;
    public GameObject S3_Hold_Fwd;
    public GameObject[] S3SensorCheck_1;
    //? S3

    public GameObject S5_Slide_Dn;
    public GameObject[] S5SensorCheck_1;
    //? S4
    public GameObject S4_Horz_Snr_On, S4_Horz_Snr_Off, S4_Vert_Up, S4_Vert_Dn, S4_Horz_Fwd, S4_Horz_Rev;
    //public GameObject[] S4_SensorCheck;
    public GameObject[] S4_GripperOn;
    //? S11/S12
    public GameObject S11_Horz_Snr_On, S11_Horz_Snr_Off, S12_Gripper_On, S12_Gripper_Off, S11_Horz_Fwd, S11_Horz_Rev;
    public GameObject[] S12_SensorCheck;
    public GameObject[] S11_GripperOn;
    //? S10

    public GameObject[] S10_Holding_Fwd;
    public GameObject[] S10_AirBlow_On;

    //? S6
    public TMP_Text[] S6_OperationParameter;
    //? S7
    public TMP_Text[] S7_OperationParameter;


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
            GlobalVariable.hubConnection = new HubConnectionBuilder().WithUrl(GlobalVariable.url)
            // .WithAutomaticReconnect()
            .Build();
            GlobalVariable.isConnecting = true;
        }


        GlobalVariable.hubConnection.On<string>("OnTagChanged", (str) =>
        {
            Debug.Log("$$" + str);
            DataSignalR data = JsonConvert.DeserializeObject<DataSignalR>(str);
            if (data != null)
            {
                UpdateData(data);
            }
        });
        GlobalVariable.hubConnection.On<string>("LogInfoMessage", async (str) =>
        {
            if (str.Contains("Connected"))
            {
                UpdateTopics(GlobalVariable.subscribedTopics);
                GlobalVariable.isConnecting = false;
                GlobalVariable.serverConnected = true;

                //string a = await GlobalVariable.hubConnection.InvokeAsync<string>("SendAll");

                var listInitialData = await GetBufferList();

                foreach (var data in listInitialData)
                {
                    UpdateData(data);
                }
                await GetBuffer("errorStatus");
                await alarmScript.gameObject.GetComponent<ErrorListView>().GenerateListView(GlobalVariable.errorInfors);
            }
        });

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
                    // GlobalVariable.isConnecting = false;
                    // GlobalVariable.serverConnected = true;
                    // GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
                    // UpdateTopics(GlobalVariable.subscribedTopics);
                }

            });
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
        // GlobalVariable.hubConnection.Reconnecting += (exception) =>
        //     {

        //         if (exception != null)
        //         {
        //             Debug.Log("There was an error opening the GlobalVariable.hubConnection:" + exception.GetBaseException());
        //             GlobalVariable.errorServerConnected = true;
        //             GlobalVariable.isConnecting = false;
        //         }

        //         GlobalVariable.isConnecting = true;
        //         return Task.CompletedTask;
        //     };

        // GlobalVariable.hubConnection.Reconnected += (ConnectionId) =>
        // {
        //     GlobalVariable.isConnecting = false;
        //     GlobalVariable.serverConnected = true;
        //     return Task.CompletedTask;
        // };


    }

    public void PublishStationIndex(int index)
    {
        GlobalVariable.hubConnection.InvokeAsync("SelectStation", index);
    }
    public void UpdateTopics(List<string> topics)
    {
        GlobalVariable.hubConnection.InvokeAsync("UpdateTopics", topics);
    }
    void UpdateData(DataSignalR data)
    {
        if (data.StationId == "Metric" && data.LineId == "IE-F2-HCA01")
        {
            if (data.TagId.Contains("/"))
            {

                //! S1
                if (data.TagId.Contains("S1/in/"))
                {

                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS1[index].SetActive(value);
                    GlobalVariable.inputStation1[index] = value;
                    if (index == 0)
                    {
                        if (value)
                        {
                            S1_Horz_Snr_On.SetActive(true);
                            S1_Horz_Snr_Off.SetActive(false);
                        }
                        else
                        {
                            S1_Horz_Snr_Off.SetActive(true);
                            S1_Horz_Snr_On.SetActive(false);
                        }
                    }
                    else if (index > 1 && index < 6)
                    {
                        S1_SensorCheck[index - 2].SetActive(value);
                    }
                }
                else if (data.TagId.Contains("S1/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS1[index].SetActive(value);
                    //if(index==12) GlobalVariable.outputStation1[index] = value;
                    if (index == 17 && value)
                    {

                        S1_Vert_Up.SetActive(true);
                        S1_Vert_Dn.SetActive(false);

                    }
                    else if (index == 18 && value)
                    {
                        S1_Vert_Dn.SetActive(true);
                        S1_Vert_Up.SetActive(false);
                    }
                    else if (index == 13 && value)
                    {
                        S1_Horz_Fwd.SetActive(true);
                        S1_Horz_Rev.SetActive(false);
                    }
                    else if (index == 14 && value)
                    {
                        S1_Horz_Rev.SetActive(true);
                        S1_Horz_Fwd.SetActive(false);
                    }
                    else if (index == 15 && value)
                    {
                        S1_Gripper_On.SetActive(true);
                        S1_Gripper_Off.SetActive(false);
                    }
                    else if (index == 16 && value)
                    {
                        S1_Gripper_Off.SetActive(true);
                        S1_Gripper_On.SetActive(false);
                    }
                }
                //! S2
                else if (data.TagId.Contains("S2/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS2[index].SetActive(value);

                    if (index == 0)
                    {
                        if (value)
                        {
                            S2_Horz_Snr_On.SetActive(true);
                            S2_Horz_Snr_Off.SetActive(false);
                        }
                        else
                        {
                            S2_Horz_Snr_Off.SetActive(true);
                            S2_Horz_Snr_On.SetActive(false);
                        }
                    }
                    // else if (index != 0 && index != 1)
                    // {
                    //     S2SensorCheck[index - 2].SetActive(value);
                    // }

                }
                else if (data.TagId.Contains("S2/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS2[index].SetActive(value);
                    if (index == 6)
                    {
                        S2_GripperOn[0].SetActive(value);

                    }
                    else if (index == 7)
                    {
                        S2_GripperOn[1].SetActive(value);

                    }
                    else if (index == 8)
                    {
                        S2_GripperOn[2].SetActive(value);

                    }
                    else if (index == 9)
                    {
                        S2_GripperOn[3].SetActive(value);
                    }
                    else if (index == 17 && value)
                    {

                        S2_Vert_Up.SetActive(true);
                        S2_Vert_Dn.SetActive(false);

                    }
                    else if (index == 18 && value)
                    {
                        S2_Vert_Dn.SetActive(true);
                        S2_Vert_Up.SetActive(false);
                    }
                    else if (index == 15 && value)
                    {
                        S2_Horz_Fwd.SetActive(true);
                        S2_Horz_Rev.SetActive(false);
                    }
                    else if (index == 16 && value)
                    {
                        S2_Horz_Rev.SetActive(true);
                        S2_Horz_Fwd.SetActive(false);
                    }
                    else if (index == 3)
                    {
                        if (value)
                        {
                            S2_Vacuum_On.SetActive(true);
                        }
                        else
                        {
                            S2_Vacuum_On.SetActive(false);
                        }
                    }


                }
                //! S3
                else if (data.TagId.Contains("S3/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS3[index].SetActive(value);
                    if (index > 0 && index < 5)
                    {
                        S3SensorCheck_1[index - 1].SetActive(value);
                    }


                }
                else if (data.TagId.Contains("S3/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS3[index].SetActive(value);
                    if (index == 1)
                    {
                        S3_Press_Dn[0].SetActive(value);

                    }
                    else if (index == 3)
                    {
                        S3_Press_Dn[1].SetActive(value);

                    }
                    else if (index == 5)
                    {
                        S3_Press_Dn[2].SetActive(value);

                    }
                    else if (index == 7)
                    {
                        S3_Press_Dn[3].SetActive(value);
                    }
                    else if (index == 8 && value)
                    {

                        S3_Hold_Fwd.SetActive(true);


                    }
                    else if (index == 9 && value)
                    {
                        S3_Hold_Fwd.SetActive(false);

                    }
                }
                //! S4
                else if (data.TagId.Contains("S4/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS4[index].SetActive(value);
                    if (index == 0)
                    {
                        // Debug.Log("lên");
                        if (value)
                        {
                            S4_Horz_Snr_On.SetActive(true);
                            S4_Horz_Snr_Off.SetActive(false);
                        }
                        else
                        {
                            S4_Horz_Snr_Off.SetActive(true);
                            S4_Horz_Snr_On.SetActive(false);
                        }
                    }
                    // else if (index >= 6 && index <= 9)
                    // {
                    //     S4_SensorCheck[index - 6].SetActive(value);
                    // }


                }
                else if (data.TagId.Contains("S4/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS4[index].SetActive(value);
                    if (index == 22 && value)
                    {

                        S4_Vert_Up.SetActive(true);
                        S4_Vert_Dn.SetActive(false);

                    }
                    else if (index == 23 && value)
                    {
                        S4_Vert_Dn.SetActive(true);
                        S4_Vert_Up.SetActive(false);
                    }
                    else if (index == 13 && value)
                    {
                        S4_Horz_Fwd.SetActive(true);
                        S4_Horz_Rev.SetActive(false);
                    }
                    else if (index == 12 && value)
                    {
                        S4_Horz_Rev.SetActive(true);
                        S4_Horz_Fwd.SetActive(false);
                    }
                    else if (index == 14 && value)
                    {
                        S4_GripperOn[0].SetActive(true);
                    }
                    else if (index == 15 && value)
                    {
                        S4_GripperOn[0].SetActive(false);
                    }
                    else if (index == 16 && value)
                    {
                        S4_GripperOn[1].SetActive(true);
                    }
                    else if (index == 17 && value)
                    {
                        S4_GripperOn[1].SetActive(false);
                    }
                    else if (index == 18 && value)
                    {
                        S4_GripperOn[2].SetActive(true);
                    }
                    else if (index == 19 && value)
                    {
                        S4_GripperOn[2].SetActive(false);
                    }
                    else if (index == 20 && value)
                    {
                        S4_GripperOn[3].SetActive(true);
                    }
                    else if (index == 21 && value)
                    {
                        S4_GripperOn[3].SetActive(false);
                    }

                }
                //! S5
                else if (data.TagId.Contains("S5/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 6));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS5[index].SetActive(value);
                    if (index > 0)
                    {
                        S5SensorCheck_1[index - 1].SetActive(value);
                    }

                }
                else if (data.TagId.Contains("S5/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS5[index].SetActive(value);
                    if (index == 1 && value)
                    {

                        S5_Slide_Dn.SetActive(true);


                    }
                    else if (index == 0 && value)
                    {
                        S5_Slide_Dn.SetActive(false);

                    }
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
                else if (data.TagId.Contains("S6/parameter/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 13));
                    double value = double.Parse(data.TagValue);
                    S6_OperationParameter[index].text = value.ToString();
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
                else if (data.TagId.Contains("S7/parameter/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 13));
                    double value = double.Parse(data.TagValue);
                    S7_OperationParameter[index].text = value.ToString();
                }
                //! S8 
                else if (data.TagId.Contains("S8"))
                {
                    if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR1"))
                    {
                        GlobalVariable.S8_max_1 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR1"))
                    {
                        GlobalVariable.S8_min_1 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR1"))
                    {
                        GlobalVariable.S8_current_1 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR1"))
                    {
                        GlobalVariable.S8_measured_1 = double.Parse(data.TagValue);
                        Debug.Log(GlobalVariable.S8_measured_1);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR1"))
                    {
                        GlobalVariable.S8_offset_1 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR3"))
                    {
                        GlobalVariable.S8_max_3 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR3"))
                    {
                        GlobalVariable.S8_min_3 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR3"))
                    {
                        GlobalVariable.S8_current_3 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR3"))
                    {
                        GlobalVariable.S8_measured_3 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR3"))
                    {
                        GlobalVariable.S8_offset_3 = double.Parse(data.TagValue);

                    }
                }
                //! S9
                else if (data.TagId.Contains("S9"))
                {
                    // if (data.TagId.Contains("TOTAL_HEIGHT_TR2"))
                    // {
                    //     Debug.Log(msg);
                    //     Debug.Log(double.Parse(data.TagValue));

                    // }
                    if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR2"))
                    {
                        GlobalVariable.S9_max_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR2"))
                    {
                        GlobalVariable.S9_min_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR2"))
                    {
                        GlobalVariable.S9_current_2 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR2"))
                    {
                        GlobalVariable.S9_measured_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR2"))
                    {
                        GlobalVariable.S9_offset_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR4"))
                    {
                        GlobalVariable.S9_max_4 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR4"))
                    {
                        GlobalVariable.S9_min_4 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR4"))
                    {
                        GlobalVariable.S9_current_4 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR4"))
                    {
                        GlobalVariable.S9_measured_4 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR4"))
                    {
                        GlobalVariable.S9_offset_4 = double.Parse(data.TagValue);

                    }
                }
                //! S10
                else if (data.TagId.Contains("S10/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS10[index].SetActive(value);


                }
                else if (data.TagId.Contains("S10/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS10[index].SetActive(value);
                    if (index < 4) S10_AirBlow_On[index].SetActive(value);


                }

                //!- S11
                else if (data.TagId.Contains("S11/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS11[index].SetActive(value);
                    if (index == 0)
                    {
                        if (value)
                        {
                            S11_Horz_Snr_On.SetActive(true);
                            S11_Horz_Snr_Off.SetActive(false);
                        }
                        else
                        {
                            S11_Horz_Snr_Off.SetActive(true);
                            S11_Horz_Snr_On.SetActive(false);
                        }
                    }

                }
                else if (data.TagId.Contains("S11/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS11[index].SetActive(value);
                    if (index == 0 && value)
                    {

                        S11_Horz_Fwd.SetActive(true);
                        S11_Horz_Rev.SetActive(false);

                    }
                    else if (index == 1 && value)
                    {
                        S11_Horz_Rev.SetActive(true);
                        S11_Horz_Fwd.SetActive(false);
                    }
                    else if (index == 2 && value)
                    {
                        S11_GripperOn[0].SetActive(true);
                    }
                    else if (index == 3 && value)
                    {
                        S11_GripperOn[0].SetActive(false);
                    }
                    else if (index == 4 && value)
                    {
                        S11_GripperOn[1].SetActive(true);
                    }
                    else if (index == 5 && value)
                    {
                        S11_GripperOn[1].SetActive(false);
                    }
                    else if (index == 6 && value)
                    {
                        S11_GripperOn[2].SetActive(true);
                    }
                    else if (index == 7 && value)
                    {
                        S11_GripperOn[2].SetActive(false);
                    }
                    else if (index == 8 && value)
                    {
                        S11_GripperOn[3].SetActive(true);
                    }
                    else if (index == 9 && value)
                    {
                        S11_GripperOn[3].SetActive(false);
                    }
                }
                //! S12
                else if (data.TagId.Contains("S12/in/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 7));
                    bool value = data.TagValue == "1" ? true : false;
                    inputCheckS12[index].SetActive(value);
                    S12_SensorCheck[index].SetActive(value);
                }
                else if (data.TagId.Contains("S12/out/"))
                {
                    int index = int.Parse(data.TagId.Remove(0, 8));
                    bool value = data.TagValue == "1" ? true : false;
                    outputCheckS12[index].SetActive(value);
                    if (index == 0 && value)
                    {

                        S12_Gripper_On.SetActive(true);
                        S12_Gripper_Off.SetActive(false);

                    }
                    else if (index == 1 && value)
                    {
                        S12_Gripper_Off.SetActive(true);
                        S12_Gripper_On.SetActive(false);
                    }
                }
            }
            else if (data.TagId.Contains("HEIGHT"))
            {
                if (data.TagId.Contains("S8"))
                {
                    if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR1"))
                    {
                        GlobalVariable.S8_max_1 = double.Parse(data.TagValue);


                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR1"))
                    {
                        GlobalVariable.S8_min_1 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR1"))
                    {
                        GlobalVariable.S8_current_1 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR1"))
                    {
                        GlobalVariable.S8_measured_1 = double.Parse(data.TagValue);
                        // Debug.Log(GlobalVariable.S8_measured_1);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR1"))
                    {
                        GlobalVariable.S8_offset_1 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR3"))
                    {
                        GlobalVariable.S8_max_3 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR3"))
                    {
                        GlobalVariable.S8_min_3 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR3"))
                    {
                        GlobalVariable.S8_current_3 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR3"))
                    {
                        GlobalVariable.S8_measured_3 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR3"))
                    {
                        GlobalVariable.S8_offset_3 = double.Parse(data.TagValue);

                    }
                }
                //! S9
                else if (data.TagId.Contains("S9"))
                {
                    if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR2"))
                    {
                        GlobalVariable.S9_max_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR2"))
                    {
                        GlobalVariable.S9_min_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR2"))
                    {
                        GlobalVariable.S9_current_2 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR2"))
                    {
                        GlobalVariable.S9_measured_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR2"))
                    {
                        GlobalVariable.S9_offset_2 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MAXIMUM_HEIGHT_VALUE_TR4"))
                    {
                        GlobalVariable.S9_max_4 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("MINIMUN_HEIGHT_VALUE_TR4"))
                    {
                        GlobalVariable.S9_min_4 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("CURRENT_HEIGHT_TR4"))
                    {
                        GlobalVariable.S9_current_4 = double.Parse(data.TagValue);
                    }
                    else if (data.TagId.Contains("TOTAL_HEIGHT_TR4"))
                    {
                        GlobalVariable.S9_measured_4 = double.Parse(data.TagValue);

                    }
                    else if (data.TagId.Contains("OFF_SET_TR4"))
                    {
                        GlobalVariable.S9_offset_4 = double.Parse(data.TagValue);

                    }
                }
                else if (data.TagId.Contains("REJ"))
                {
                    //data.TagId.Contains("HEIGHT_CHK_REJ_TR")
                    int index = int.Parse(data.TagId.Remove(0, 17));
                    GlobalVariable.RejCountS89TR[index - 1] = int.Parse(data.TagValue);
                }
            }

            else if (data.TagId.Contains("CHECK_PRESSURE_S10_TRACK"))
            {
                int index = int.Parse(data.TagId.Remove(0, 24)) - 1;
                bool value = data.TagValue == "1" ? true : false;
                S10SensorCheck[index].SetActive(value);


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
                        if (data.TagValue != "Wifi disconnected" && GlobalVariable.errorInfors.Any(x => x.errorName == data.TagValue) == false)

                        {
                            Debug.Log(data.TagValue);
                            errorInfor = new ErrorInfor { errorName = data.TagValue, time = data.TimeStamp.ToString("HH:mm:ss dd/MM/yyyy") };
                            GlobalVariable.errorInfors.Add(errorInfor);
                            alarmScript.gameObject.GetComponent<ErrorListView>().GenerateListView(GlobalVariable.errorInfors);
                        }
                        break;
                    case "endErrorStatus":
                        //linQ
                        GlobalVariable.errorInfors.RemoveAll(x => x.errorName == data.TagValue);
                        // errorInfor = new ErrorInfor { errorName = data.TagValue, time = data.TimeStamp.ToString("HH:mm:ss dd/MM/yyyy") };
                        // for (int i = 0; i < GlobalVariable.errorInfors.Count; i++)
                        // {
                        //     if (GlobalVariable.errorInfors[i].errorName == errorInfor.errorName)
                        //     {
                        //         GlobalVariable.errorInfors.RemoveAt(i);
                        //         break;
                        //     }
                        // }
                        alarmScript.gameObject.GetComponent<ErrorListView>().GenerateListView(GlobalVariable.errorInfors);
                        break;
                    default:
                        break;
                }
            }

        }
    }
    public async Task GetBuffer(string tagId)
    {
        var response = await GlobalVariable.hubConnection.InvokeAsync<string>("SendAll");
        var tags = JsonConvert.DeserializeObject<List<DataSignalR>>(response);
        var filteredList = tags.Where(data => data.TagId == tagId);
        ErrorInfor errorInfor;
        GlobalVariable.errorInfors.Clear();
        foreach (var tag in filteredList)
        {
            if (tag.TagValue != "Wifi disconnected")
            {
                Debug.Log("Error: " + tag.TagValue + " at " + tag.TimeStamp.ToString("HH:mm:ss dd/MM/yyyy"));
                errorInfor = new ErrorInfor { errorName = tag.TagValue, time = tag.TimeStamp.ToString("HH:mm:ss dd/MM/yyyy") };
                GlobalVariable.errorInfors.Add(errorInfor);
            }
        }
    }
    public async Task<List<DataSignalR>> GetBufferList()
    {
        var response = await GlobalVariable.hubConnection.InvokeAsync<string>("SendAll");
        var tags = JsonConvert.DeserializeObject<List<DataSignalR>>(response);
        if (tags is null) return new List<DataSignalR>();
        return tags;

    }
}

