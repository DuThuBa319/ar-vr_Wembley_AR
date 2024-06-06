using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_6 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation6 = new List<string> {

         $"{GlobalVariable.basedTopic}/S6/in/00" ,
         $"{GlobalVariable.basedTopic}/S6/in/01" ,
         $"{GlobalVariable.basedTopic}/S6/in/02" ,
         $"{GlobalVariable.basedTopic}/S6/in/03" ,
         $"{GlobalVariable.basedTopic}/S6/in/04" ,
         $"{GlobalVariable.basedTopic}/S6/in/05" ,
         $"{GlobalVariable.basedTopic}/S6/in/06" ,
         $"{GlobalVariable.basedTopic}/S6/out/00" ,
         $"{GlobalVariable.basedTopic}/S6/out/01" ,
         $"{GlobalVariable.basedTopic}/S6/out/02" ,
         $"{GlobalVariable.basedTopic}/S6/out/03" ,
         $"{GlobalVariable.basedTopic}/S6/out/04" ,
         $"{GlobalVariable.basedTopic}/S6/out/05" ,
         $"{GlobalVariable.basedTopic}/S6/out/06" ,
         $"{GlobalVariable.basedTopic}/S6/out/07" ,
         $"{GlobalVariable.basedTopic}/S6/out/08" ,
         };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation6);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation6);
    }
}

