using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using System;
using TMPro;

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
    public GameObject motorImg ;
    public Sprite motorOn, motorOff;
    // public Text mqttAdress,valueSimulationText;
    public TMP_Text mqttAdress, valueSimulationText,connectionStatusText;
    protected override void Start()
    {
        base.Start();
        motorImg.GetComponent<Image>().sprite = motorOff;
    }
    protected override void OnConnecting()
    {
        base.OnConnecting();
        connectionStatusText.text = "Connecting...";
        Debug.Log("Connecting");

    }
    protected override void OnConnected()
    {
        base.OnConnected();
        connectionStatusText.text = "Connected";
        Debug.Log("Connected");

    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { "AR/01/Metric/Enocder Value" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

    }
    public void Publish_Message()
    {

      //  client.Publish("iotgateway/write", System.Text.Encoding.UTF8.GetBytes("[{\"id\":\"Channel1.Device1.PV_Counter\",\"v\":\"6\"}]"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

    }
    protected override void DecodeMessage(string topic, byte[] message)
    {
        Debug.Log("Da nhan");
        int c = 0;
        string msg = System.Text.Encoding.UTF8.GetString(message);

        Debug.Log(msg);
        /*
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
        if (topic == "AR/01/Metric/Enocder Value")
        {
            Data jsondata0 = Data.CreateFromJSON(msg);
            valueSimulationText.text = jsondata0.value.ToString();
            /*if (bool.Parse(jsondata0.value))
            {
                valueSimulationText.text = "true";
            }
            else
            {
                valueSimulationText.text = "false";
            }
          /*  if (float.Parse(jsondata0.value) < 0)
            {
                value_speed = 0 - (int)float.Parse(jsondata0.value);
            }
            else value_speed = (int)float.Parse(jsondata0.value);

            speed_value_txt.text = (value_speed).ToString() + " rpm";     */
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
        Debug.Log(mqttAdress.text);
        brokerAddress = mqttAdress.text;
        Connect();
    }

}
