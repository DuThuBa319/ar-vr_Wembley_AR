using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_7 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation7 = new List<string> {
         $"{GlobalVariable.basedTopic}/Encoder Value" ,
$"{GlobalVariable.basedTopic}/S7/in/00" ,
       $"{GlobalVariable.basedTopic}/S7/in/01" ,
       $"{GlobalVariable.basedTopic}/S7/in/02" ,
       $"{GlobalVariable.basedTopic}/S7/in/03" ,
       $"{GlobalVariable.basedTopic}/S7/in/04" ,
       $"{GlobalVariable.basedTopic}/S7/in/05" ,
       $"{GlobalVariable.basedTopic}/S7/in/06" ,
       $"{GlobalVariable.basedTopic}/S7/out/00" ,
       $"{GlobalVariable.basedTopic}/S7/out/01" ,
       $"{GlobalVariable.basedTopic}/S7/out/02" ,
       $"{GlobalVariable.basedTopic}/S7/out/03" ,
       $"{GlobalVariable.basedTopic}/S7/out/04" ,
       $"{GlobalVariable.basedTopic}/S7/out/05" ,
       $"{GlobalVariable.basedTopic}/S7/out/06" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation7);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation7);
    }
}

