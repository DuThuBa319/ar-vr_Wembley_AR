using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationTest : MonoBehaviour
{
    private HubConnection hubConnection;
    private string url = "https://localhost:7167/NotificationHub";
    private float x= 0, y=0;
    public TMP_Text xTxt,yTxt;
    // Start is called before the first frame update
    async void  Start() 
    {
        hubConnection = new HubConnectionBuilder().WithUrl(url).Build();
        
        // Hiện thông báo đã kết nối => test xem đã kết nối chưa
        hubConnection.On<string>("OnMessage", (str) => { Debug.Log(str); });
        // Nhận 2 số từ Hub => biết cách nhận dữ liệu 
      
        hubConnection.On<float,float>("GetTwoNumbers", (n1,n2) => {
            x = n1; y = n2;
            xTxt.text = n1.ToString(); yTxt.text = n2.ToString();   
            Debug.Log("Đã nhận số");
            Debug.Log($"{x}:{y}"); });
        
        try
        {
           await hubConnection.StartAsync();
            //Debug.Log("connecting with server");
        }
        catch (Exception e) {
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
