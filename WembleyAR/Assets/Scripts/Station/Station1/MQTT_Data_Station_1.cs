using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_1 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation1 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S1/in/00" ,
         $"{GlobalVariable.basedTopic}/S1/in/01" ,
         $"{GlobalVariable.basedTopic}/S1/in/02" ,
         $"{GlobalVariable.basedTopic}/S1/in/03" ,
         $"{GlobalVariable.basedTopic}/S1/in/04" ,
         $"{GlobalVariable.basedTopic}/S1/in/05" ,
         $"{GlobalVariable.basedTopic}/S1/in/06" ,
         $"{GlobalVariable.basedTopic}/S1/in/07" ,
         $"{GlobalVariable.basedTopic}/S1/in/08" ,
         $"{GlobalVariable.basedTopic}/S1/in/09" ,
         $"{GlobalVariable.basedTopic}/S1/in/10" ,
         $"{GlobalVariable.basedTopic}/S1/in/11" ,
         $"{GlobalVariable.basedTopic}/S1/in/12" ,
         $"{GlobalVariable.basedTopic}/S1/in/13" ,
         $"{GlobalVariable.basedTopic}/S1/out/00" ,
         $"{GlobalVariable.basedTopic}/S1/out/01" ,
         $"{GlobalVariable.basedTopic}/S1/out/02" ,
         $"{GlobalVariable.basedTopic}/S1/out/03" ,
         $"{GlobalVariable.basedTopic}/S1/out/04" ,
         $"{GlobalVariable.basedTopic}/S1/out/05" ,
         $"{GlobalVariable.basedTopic}/S1/out/06" ,
         $"{GlobalVariable.basedTopic}/S1/out/07" ,
         $"{GlobalVariable.basedTopic}/S1/out/08" ,
         $"{GlobalVariable.basedTopic}/S1/out/09" ,
         $"{GlobalVariable.basedTopic}/S1/out/10" ,
         $"{GlobalVariable.basedTopic}/S1/out/11" ,
         $"{GlobalVariable.basedTopic}/S1/out/12" ,
         $"{GlobalVariable.basedTopic}/S1/out/13" ,
         $"{GlobalVariable.basedTopic}/S1/out/14" ,
         $"{GlobalVariable.basedTopic}/S1/out/15" ,
         $"{GlobalVariable.basedTopic}/S1/out/16" ,
         $"{GlobalVariable.basedTopic}/S1/out/17" ,
         $"{GlobalVariable.basedTopic}/S1/out/18" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.Publish_Message(1);
        mqtt.SubscribeTopic(topicStation1);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation1);
        mqtt.Publish_Message(0);
    }
}

