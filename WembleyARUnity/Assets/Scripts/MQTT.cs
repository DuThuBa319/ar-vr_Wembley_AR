using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using System;
using TMPro;
using Unity.VisualScripting;

[Serializable]
public class Data
{
    public string name;
    public string value;
    public string timestamp;

    public static Data CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Data>(jsonString);
    }

}
public class TagMessage
{
    public string TagName { get; set; }
    public string TagValue { get; set; }
    public TagMessage(string _tagName, string _tagValue)
    {
        TagName = _tagName;
        TagValue = _tagValue;
    }
}

public class MQTT : M2MqttUnity.M2MqttUnityClient
{


    // public Text mqttAdress,valueSimulationText;
    // public TMP_Text mqttAdress, valueSimulationText;
    protected override void Start()
    {
        base.Start();
        brokerAddress = "40.82.154.13";
        Connect();
    }
    protected override void OnConnecting()
    {
        base.OnConnecting();
        Debug.Log("Connecting");

    }
    protected override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Connected");
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { "Wembley/AR/Encoder Value" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/in/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/14" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/15" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/16" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/17" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/18" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/19" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/20" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/21" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/22" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/23" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/24" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/25" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/26" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/27" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/28" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/29" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/30" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/31" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/AR/S1/out/32" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

    }
    public void Publish_Message()
    {

        //  client.Publish("iotgateway/write", System.Text.Encoding.UTF8.GetBytes("[{\"id\":\"Channel1.Device1.PV_Counter\",\"v\":\"6\"}]"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

    }
    protected override void DecodeMessage(string topic, byte[] message)
    {
        /*
        Debug.Log("Da nhan");
        int c = 0;
        string msg = System.Text.Encoding.UTF8.GetString(message);

        Debug.Log(msg);
        
                foreach (char chr in msg)
                {
                    if (chr == ';') c += 1;
                }
                string[] Tach_Chuoi_msg = msg.Split(";");

                Data[] jsondata = new Data[c];

                for (int i = 0; i < c; i++)
                {
                    jsondata[i] = Data.CreateFromJSON(Tach_Chuoi_msg[i]);

                    if (jsondata[i].name == "PLC.PLC.motorStatus")
                    {
                        if (jsondata[i].value == "true")
                        {
                            motorImg.GetComponent<Image>().sprite = motorOn;
                        }
                        else
                        {
                            motorImg.GetComponent<Image>().sprite = motorOff;
                        } 
                    }
                }  */
        string valueKey = topic.Remove(0, 11);
        string msg = System.Text.Encoding.UTF8.GetString(message);

        if (topic.Contains("Encoder Value"))
        {
            GlobalVariable.encoderPosition = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("S1/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            GlobalVariable.inputStation1[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S1/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.outputStation1[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
    }


    public void onStartBtnClick()
    {
        client.Publish("iotgateway/write", System.Text.Encoding.UTF8.GetBytes("[{\"id\":\"PLC.PLC.startBtn\",\"v\":true}]"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
        client.Publish("iotgateway/write", System.Text.Encoding.UTF8.GetBytes("[{\"id\":\"PLC.PLC.startBtn\",\"v\":false}]"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
    }
    public void onStopBtnClick()
    {
        client.Publish("iotgateway/write", System.Text.Encoding.UTF8.GetBytes("[{\"id\":\"PLC.PLC.stopBtn\",\"v\":true}]"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
        client.Publish("iotgateway/write", System.Text.Encoding.UTF8.GetBytes("[{\"id\":\"PLC.PLC.stopBtn\",\"v\":false}]"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
    }
    public void onConnectBtnClick()
    {
        // Debug.Log(mqttAdress.text);
        // brokerAddress = mqttAdress.text;
        Connect();
    }

}
