using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_3 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation3 = new List<string> {
         $"{GlobalVariable.basedTopic}/Encoder Value" ,
        $"{GlobalVariable.basedTopic}/S3/in/00" ,
         $"{GlobalVariable.basedTopic}/S3/in/01" ,
         $"{GlobalVariable.basedTopic}/S3/in/02" ,
         $"{GlobalVariable.basedTopic}/S3/in/03" ,
         $"{GlobalVariable.basedTopic}/S3/in/04" ,
         $"{GlobalVariable.basedTopic}/S3/in/05" ,
         $"{GlobalVariable.basedTopic}/S3/in/06" ,
         $"{GlobalVariable.basedTopic}/S3/in/07" ,
         $"{GlobalVariable.basedTopic}/S3/in/08" ,
         $"{GlobalVariable.basedTopic}/S3/out/00" ,
         $"{GlobalVariable.basedTopic}/S3/out/01" ,
         $"{GlobalVariable.basedTopic}/S3/out/02" ,
         $"{GlobalVariable.basedTopic}/S3/out/03" ,
         $"{GlobalVariable.basedTopic}/S3/out/04" ,
         $"{GlobalVariable.basedTopic}/S3/out/05" ,
         $"{GlobalVariable.basedTopic}/S3/out/06" ,
         $"{GlobalVariable.basedTopic}/S3/out/07" ,
         $"{GlobalVariable.basedTopic}/S3/out/08" ,
         $"{GlobalVariable.basedTopic}/S3/out/09" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation3);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation3);
    }
}

