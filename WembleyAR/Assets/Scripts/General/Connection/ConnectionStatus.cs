using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ConnectionStatus : MonoBehaviour
{
    public TMP_Text connectionStatusText;



    void Update()
    {
        if (GlobalVariable.networkConnected)
        {

            if (GlobalVariable.isConnecting)
            {
                connectionStatusText.text = "Đang kết nối";
                connectionStatusText.color = Color.yellow;
            }
            else
            {
                if (GlobalVariable.serverConnected)
                {
                    connectionStatusText.text = "Đã kết nối";
                    connectionStatusText.color = Color.green;
                }
                else
                {
                    if (GlobalVariable.errorServerConnected)
                    {
                        connectionStatusText.text = "Xảy ra lỗi kết nối với server";
                        connectionStatusText.color = Color.red;
                    }
                    else
                    {
                        connectionStatusText.text = "Mất kết nối với server";
                        connectionStatusText.color = Color.red;
                    }

                }
            }
        }
        else
        {
            connectionStatusText.text = "Mất kết nối với mạng";
            connectionStatusText.color = Color.red;
        }


    }
    public void ConnectToServer()
    {
        GlobalVariable.isConnecting = true;
        GlobalVariable.hubConnection.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("There was an error opening the connection:" + task.Exception.GetBaseException());
                    GlobalVariable.errorServerConnected = true;
                }
                if (task.IsCompletedSuccessfully)
                {
                    GlobalVariable.isConnecting = false;
                    GlobalVariable.serverConnected = true;
                }

            });
    }
    public void DisconnectFromServer()
    {
        GlobalVariable.hubConnection.StopAsync().ContinueWith(task =>
            {

                if (task.IsFaulted)
                {
                    Debug.Log("There was an error opening the connection:" + task.Exception.GetBaseException());
                    GlobalVariable.isConnecting = false;
                }
                if (task.IsCompleted)
                {
                    GlobalVariable.serverConnected = false;
                    GlobalVariable.isConnecting = false;
                }

            });
    }

}
