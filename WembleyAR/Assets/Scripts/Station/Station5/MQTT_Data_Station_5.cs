using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_5 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation5 = new List<string> {
        //   ,
 $"{GlobalVariable.basedTopic}/S5/in/00" ,
         $"{GlobalVariable.basedTopic}/S5/in/01" ,
         $"{GlobalVariable.basedTopic}/S5/in/02" ,
         $"{GlobalVariable.basedTopic}/S5/in/03" ,
         $"{GlobalVariable.basedTopic}/S5/in/04" ,
         $"{GlobalVariable.basedTopic}/S5/out/00" ,
         $"{GlobalVariable.basedTopic}/S5/out/01" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.Publish_Message(5);
        mqtt.SubscribeTopic(topicStation5);
    }

    void OnDisable()
    {

        mqtt.UnsubscribeTopic(topicStation5);
        mqtt.Publish_Message(0);
    }
}

