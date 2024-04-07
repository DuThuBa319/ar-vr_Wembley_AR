using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationTest : MonoBehaviour
{



    // Start is called before the first frame update
    async void Start()
    {


        //Screen.fullScreen = true;

        // List<string> topics = new List<string> { "Wembley/HerapinCap/IE-F2-HCA01/S1/out" };
        // HubConnection hubConnection = new HubConnectionBuilder().WithUrl(GlobalVariable.url).Build();
        // try
        // {
        //     await hubConnection.StartAsync();
        //     Debug.Log("connected");
        //     await hubConnection.InvokeAsync("UpdateTopics", topics);
        //     Debug.Log("subscribed");
        //     hubConnection.On<string>("S1Output", (str) =>
        //     {

        //         //DataSignalR data = JsonUtility.FromJson<DataSignalR>(str);
        //         Debug.Log(str);
        //         // if (data.TagId.Contains("productCount"))
        //         // {
        //         //     Debug.Log(data.TagValue);
        //         // }
        //     });
        // }
        // catch (Exception e)
        // {
        //     Debug.Log(e);
        //     throw;
        // }
        string topic = "Wembley/HerapinCap/IE-F2-HCA01/";
        GlobalVariable.hubConnection = new HubConnectionBuilder().WithUrl(GlobalVariable.url).Build();
        try
        {

            GlobalVariable.hubConnection.On<string>(topic + "S1/in/00", (str) =>
            {

                DataSignalR data = JsonUtility.FromJson<DataSignalR>(str);
                Debug.Log(str);
                // if (data.TagId.Contains("productCount"))
                // {
                //     Debug.Log(data.TagValue);
                // }
            });
            await GlobalVariable.hubConnection.StartAsync();
            Debug.Log("connected");

        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }

        // Hiện thông báo đã kết nối => test xem đã kết nối chưa
        // hubConnection.On<string>("OnMessage", (str) => { Debug.Log(str); });
        // Nhận 2 số từ Hub => biết cách nhận dữ liệu 
        // hubConnection.On<string>("S1Output", (str) =>
        //     {

        //         //DataSignalR data = JsonUtility.FromJson<DataSignalR>(str);
        //         Debug.Log(str);
        //         // if (data.TagId.Contains("productCount"))
        //         // {
        //         //     Debug.Log(data.TagValue);
        //         // }
        //     });




    }

    // Update is called once per frame
    void Update()
    {

    }
    async void OnDestroy()
    {
        if (GlobalVariable.hubConnection != null)
            await GlobalVariable.hubConnection.StopAsync();
    }
}
