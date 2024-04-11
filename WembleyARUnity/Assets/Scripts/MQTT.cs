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
public class HeightData
{
    public string name;
    public double value;
    public string timestamp;

    public static HeightData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<HeightData>(jsonString);
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
    public void SubscribeTopic(List<string> topics)
    {
        foreach (var topic in topics)
        {
            client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        }
    }
    public void UnsubscribeTopic(List<string> topics)
    {
        foreach (var topic in topics)
        {
            client.Unsubscribe(new string[] { topic });
        }
    }
    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/Encoder Value" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        /*
        //! S1
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/Encoder Value" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/in/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/14" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/15" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/16" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/17" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S1/out/18" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S2
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/Encoder Value" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/14" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/15" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/16" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/17" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S2/out/18" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S3
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/in/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S3/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S4
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/in/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/14" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/15" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/16" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/17" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/18" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/19" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/20" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/21" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/22" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S4/out/23" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S5
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S5/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S5/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S5/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S5/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S5/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S5/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S5/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S6
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S6/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S7
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S7/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });


        //! S8
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_MAXIMUM_HEIGHT_VALUE_TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_MINIMUN_HEIGHT_VALUE_TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_OFF_SET_TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_CURRENT_HEIGHT_TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_TOTAL_HEIGHT_TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_MAXIMUM_HEIGHT_VALUE_TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_MINIMUN_HEIGHT_VALUE_TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_OFF_SET_TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_CURRENT_HEIGHT_TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S8_TOTAL_HEIGHT_TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S9
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_MAXIMUM_HEIGHT_VALUE_TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_MINIMUN_HEIGHT_VALUE_TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_OFF_SET_TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_CURRENT_HEIGHT_TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_TOTAL_HEIGHT_TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_MAXIMUM_HEIGHT_VALUE_TR4" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_MINIMUN_HEIGHT_VALUE_TR4" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_OFF_SET_TR4" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_CURRENT_HEIGHT_TR4" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S9_TOTAL_HEIGHT_TR4" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S10
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S10/out/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S11
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S11/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S12
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S12/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S12/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S12/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S12/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S12/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "HCM/IE-F2-HCA01/Metric/S12/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
*/
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

        string valueKey = topic.Remove(0, 23);
        string msg = System.Text.Encoding.UTF8.GetString(message);

        msg = msg.TrimStart("[").TrimEnd("]");

        if (topic.Contains("Encoder Value"))
        { 
            GlobalVariable.encoderPosition = int.Parse(Data.CreateFromJSON(msg).value);

        }
        //! S1
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
        //! S2
        else if (valueKey.Contains("S2/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            GlobalVariable.inputStation2[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;

        }
        else if (valueKey.Contains("S2/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.outputStation2[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        //! S3
        else if (valueKey.Contains("S3/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            GlobalVariable.inputStation3[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S3/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.outputStation3[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        //! S4
        else if (valueKey.Contains("S4/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            GlobalVariable.inputStation4[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S4/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.outputStation4[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        //! S5
        else if (valueKey.Contains("S5/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            GlobalVariable.inputStation5[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S5/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.outputStation5[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        //! S6
        else if (valueKey.Contains("S6/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            GlobalVariable.inputStation6[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S6/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.outputStation6[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        //! S7
        else if (valueKey.Contains("S7/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            GlobalVariable.inputStation7[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S7/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.outputStation7[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }

        //! S8 
        else if (valueKey.Contains("S8"))
        {
            if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR1"))
            {
                GlobalVariable.S8_max_1 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR1"))
            {
                GlobalVariable.S8_min_1 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR1"))
            {
                GlobalVariable.S8_current_1 = HeightData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR1"))
            {
                GlobalVariable.S8_measured_1 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("OFF_SET_TR1"))
            {
                GlobalVariable.S8_offset_1 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR3"))
            {
                GlobalVariable.S8_max_3 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR3"))
            {
                GlobalVariable.S8_min_3 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR3"))
            {
                GlobalVariable.S8_current_3 = HeightData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR3"))
            {
                GlobalVariable.S8_measured_3 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("OFF_SET_TR3"))
            {
                GlobalVariable.S8_offset_3 = HeightData.CreateFromJSON(msg).value;

            }
        }
        //! S9
        else if (valueKey.Contains("S9"))
        {
            // if (valueKey.Contains("TOTAL_HEIGHT_TR2"))
            // {
            //     Debug.Log(msg);
            //     Debug.Log(HeightData.CreateFromJSON(msg).value);

            // }
            if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR2"))
            {
                GlobalVariable.S9_max_2 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR2"))
            {
                GlobalVariable.S9_min_2 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR2"))
            {
                GlobalVariable.S9_current_2 = HeightData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR2"))
            {
                GlobalVariable.S9_measured_2 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("OFF_SET_TR2"))
            {
                GlobalVariable.S9_offset_2 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR4"))
            {
                GlobalVariable.S9_max_4 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR4"))
            {
                GlobalVariable.S9_min_4 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR4"))
            {
                GlobalVariable.S9_current_4 = HeightData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR4"))
            {
                GlobalVariable.S9_measured_4 = HeightData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("OFF_SET_TR4"))
            {
                GlobalVariable.S9_offset_4 = HeightData.CreateFromJSON(msg).value;

            }
        }
        //! S10
        else if (valueKey.Contains("S10/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.inputStation10[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S10/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 8));
            GlobalVariable.outputStation10[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        //! S11
        else if (valueKey.Contains("S11/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.inputStation11[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S11/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 8));
            GlobalVariable.outputStation11[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        //! S12
        else if (valueKey.Contains("S12/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            GlobalVariable.inputStation12[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
        else if (valueKey.Contains("S12/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 8));
            GlobalVariable.outputStation12[index] = Data.CreateFromJSON(msg).value == "1" ? true : false;
        }
    }
}
