using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_2 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation2 = new List<string> {
         $"{GlobalVariable.basedTopic}/S2/in/00" ,
         $"{GlobalVariable.basedTopic}/S2/in/01" ,
         $"{GlobalVariable.basedTopic}/S2/in/02" ,
         $"{GlobalVariable.basedTopic}/S2/in/03" ,
         $"{GlobalVariable.basedTopic}/S2/in/04" ,
         $"{GlobalVariable.basedTopic}/S2/in/05" ,
         $"{GlobalVariable.basedTopic}/S2/out/00" ,
         $"{GlobalVariable.basedTopic}/S2/out/01" ,
         $"{GlobalVariable.basedTopic}/S2/out/02" ,
         $"{GlobalVariable.basedTopic}/S2/out/03" ,
         $"{GlobalVariable.basedTopic}/S2/out/04" ,
         $"{GlobalVariable.basedTopic}/S2/out/05" ,
         $"{GlobalVariable.basedTopic}/S2/out/06" ,
         $"{GlobalVariable.basedTopic}/S2/out/07" ,
         $"{GlobalVariable.basedTopic}/S2/out/08" ,
         $"{GlobalVariable.basedTopic}/S2/out/09" ,
         $"{GlobalVariable.basedTopic}/S2/out/10" ,
         $"{GlobalVariable.basedTopic}/S2/out/11" ,
         $"{GlobalVariable.basedTopic}/S2/out/12" ,
         $"{GlobalVariable.basedTopic}/S2/out/13" ,
         $"{GlobalVariable.basedTopic}/S2/out/14" ,
         $"{GlobalVariable.basedTopic}/S2/out/15" ,
         $"{GlobalVariable.basedTopic}/S2/out/16" ,
         $"{GlobalVariable.basedTopic}/S2/out/17" ,
         $"{GlobalVariable.basedTopic}/S2/out/18" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.Publish_Message(2);
        mqtt.SubscribeTopic(topicStation2);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation2);
        mqtt.Publish_Message(0);
    }
}

