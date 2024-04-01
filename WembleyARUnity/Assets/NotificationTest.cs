using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationTest : MonoBehaviour
{

    private float x = 0, y = 0;
    public TMP_Text xTxt, yTxt;
    // Start is called before the first frame update
    async void Start()
    {
        GlobalVariable.hubConnection = new HubConnectionBuilder().WithUrl(GlobalVariable.url).Build();
        //  await hubConnection.InvokeAsync("UpdateTopic",url);
        // Hiện thông báo đã kết nối => test xem đã kết nối chưa
        // hubConnection.On<string>("OnMessage", (str) => { Debug.Log(str); });
        // Nhận 2 số từ Hub => biết cách nhận dữ liệu 
        GlobalVariable.hubConnection.On<string>("TagChanged", (str) =>
            {

                DataSignalR data = JsonUtility.FromJson<DataSignalR>(str);
                //Debug.Log(data);
                if (data.TagId.Contains("productCount"))
                {
                    Debug.Log(data.TagValue);
                }
            });

        try
        {
            await GlobalVariable.hubConnection.StartAsync();
            Debug.Log("connected");
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onClickButton()
    {
        // gửi 1 số đi để xử lý => biết cách gửi dữ liệu
        //  data= hubConnection.InvokeAsync("SendNumber");
        Debug.Log("Đã gửi số");
    }
}
