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

        //! S1
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/Encoder Value" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/in/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/12" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/13" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/14" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/15" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/16" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/17" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S1/out/18" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

        //! S3
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/in/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S3/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S5
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S5/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S5/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S5/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S5/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S5/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S5/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S5/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S6
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S6/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S7
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S7/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S10
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/in/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/00" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/01" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/02" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/03" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/04" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/05" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/06" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/07" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/08" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/09" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/10" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S10/out/11" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

        //! S8
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 MAXIMUM HEIGHT VALUE TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 MINIMUN HEIGHT VALUE TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 OFF SET TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 CURRENT HEIGHT TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 TOTAL HEIGHT TR1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 MAXIMUM HEIGHT VALUE TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 MINIMUN HEIGHT VALUE TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 OFF SET TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 CURRENT HEIGHT TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S8/S8 TOTAL HEIGHT TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //! S9
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 MAXIMUM HEIGHT VALUE TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 MINIMUN HEIGHT VALUE TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 OFF SET TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 CURRENT HEIGHT TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 TOTAL HEIGHT TR2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 MAXIMUM HEIGHT VALUE TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 MINIMUN HEIGHT VALUE TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 OFF SET TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 CURRENT HEIGHT TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        client.Subscribe(new string[] { "Wembley/HerapinCap/IE-F2-HCA01/S9/S9 TOTAL HEIGHT TR3" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

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
        //! S8 
        else if (valueKey.Contains("S8/"))
        {
            if (valueKey.Contains("MAXIMUM HEIGHT VALUE TR1"))
            {
                GlobalVariable.S8_max_1 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("MINIMUN HEIGHT VALUE TR1"))
            {
                GlobalVariable.S8_min_1 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("CURRENT HEIGHT TR1"))
            {
                GlobalVariable.S8_current_1 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;
            }
            else if (valueKey.Contains("TOTAL HEIGHT TR1"))
            {
                GlobalVariable.S8_measured_1 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("OFF SET TR1"))
            {
                GlobalVariable.S8_offset_1 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("MAXIMUM HEIGHT VALUE TR3"))
            {
                GlobalVariable.S8_max_3 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("MINIMUN HEIGHT VALUE TR3"))
            {
                GlobalVariable.S8_min_3 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("CURRENT HEIGHT TR3"))
            {
                GlobalVariable.S8_current_3 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;
            }
            else if (valueKey.Contains("TOTAL HEIGHT TR3"))
            {
                GlobalVariable.S8_measured_3 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("OFF SET TR3"))
            {
                GlobalVariable.S8_offset_3 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
        }
        //! S9
        else if (valueKey.Contains("S9/"))
        {
            if (valueKey.Contains("MAXIMUM HEIGHT VALUE TR2"))
            {
                GlobalVariable.S9_max_2 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("MINIMUN HEIGHT VALUE TR2"))
            {
                GlobalVariable.S9_min_2 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("CURRENT HEIGHT TR2"))
            {
                GlobalVariable.S9_current_2 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;
            }
            else if (valueKey.Contains("TOTAL HEIGHT TR2"))
            {
                GlobalVariable.S9_measured_2 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("OFF SET TR2"))
            {
                GlobalVariable.S9_offset_2 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("MAXIMUM HEIGHT VALUE TR3"))
            {
                GlobalVariable.S9_max_4 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("MINIMUN HEIGHT VALUE TR3"))
            {
                GlobalVariable.S9_min_4 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("CURRENT HEIGHT TR3"))
            {
                GlobalVariable.S9_current_4 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;
            }
            else if (valueKey.Contains("TOTAL HEIGHT TR3"))
            {
                GlobalVariable.S9_measured_4 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
            else if (valueKey.Contains("OFF SET TR3"))
            {
                GlobalVariable.S9_offset_4 = float.Parse(Data.CreateFromJSON(msg).value) / 100f;

            }
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
