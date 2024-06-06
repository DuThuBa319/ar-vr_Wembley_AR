using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_12 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation12 = new List<string> {
        //    ,
         $"{GlobalVariable.basedTopic}/S11/in/00",
         $"{GlobalVariable.basedTopic}/S11/out/00",
         $"{GlobalVariable.basedTopic}/S11/out/01",
         $"{GlobalVariable.basedTopic}/S11/out/02",
         $"{GlobalVariable.basedTopic}/S11/out/03",
         $"{GlobalVariable.basedTopic}/S11/out/04",
         $"{GlobalVariable.basedTopic}/S11/out/05",
         $"{GlobalVariable.basedTopic}/S11/out/06",
         $"{GlobalVariable.basedTopic}/S11/out/07",
         $"{GlobalVariable.basedTopic}/S11/out/08",
         $"{GlobalVariable.basedTopic}/S11/out/09",
         $"{GlobalVariable.basedTopic}/S12/in/00",
         $"{GlobalVariable.basedTopic}/S12/in/01",
         $"{GlobalVariable.basedTopic}/S12/in/02",
         $"{GlobalVariable.basedTopic}/S12/in/03",
         $"{GlobalVariable.basedTopic}/S12/out/00",
         $"{GlobalVariable.basedTopic}/S12/out/01",

};
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.Publish_Message(12);
        mqtt.SubscribeTopic(topicStation12);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation12);
        mqtt.Publish_Message(0);
    }
}

