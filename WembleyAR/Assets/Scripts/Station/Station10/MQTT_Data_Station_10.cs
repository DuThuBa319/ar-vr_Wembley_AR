using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_10 : MonoBehaviour
{
    MQTT mqtt;

    List<string> topicStation10 = new List<string> {
      //  ,
        $"{GlobalVariable.basedTopic}/S10/in/00" ,
         $"{GlobalVariable.basedTopic}/S10/in/01" ,
         $"{GlobalVariable.basedTopic}/S10/in/02" ,
         $"{GlobalVariable.basedTopic}/S10/in/03" ,
         $"{GlobalVariable.basedTopic}/S10/in/04" ,
         $"{GlobalVariable.basedTopic}/S10/in/05" ,
         $"{GlobalVariable.basedTopic}/S10/in/05" ,
         $"{GlobalVariable.basedTopic}/S10/in/06" ,
         $"{GlobalVariable.basedTopic}/S10/in/07" ,
         $"{GlobalVariable.basedTopic}/S10/out/00" ,
         $"{GlobalVariable.basedTopic}/S10/out/01" ,
         $"{GlobalVariable.basedTopic}/S10/out/02" ,
         $"{GlobalVariable.basedTopic}/S10/out/03" ,
         $"{GlobalVariable.basedTopic}/S10/out/04" ,
         $"{GlobalVariable.basedTopic}/S10/out/05" ,
         $"{GlobalVariable.basedTopic}/S10/out/06" ,
         $"{GlobalVariable.basedTopic}/S10/out/07" ,
         $"{GlobalVariable.basedTopic}/S10/out/08" ,
         $"{GlobalVariable.basedTopic}/S10/out/09" ,
         $"{GlobalVariable.basedTopic}/S10/out/10" ,
         $"{GlobalVariable.basedTopic}/S10/out/11" ,
         $"{GlobalVariable.basedTopic}/CHECK_PRESSURE_S10_TRACK1" ,
         $"{GlobalVariable.basedTopic}/CHECK_PRESSURE_S10_TRACK2" ,
         $"{GlobalVariable.basedTopic}/CHECK_PRESSURE_S10_TRACK3" ,
         $"{GlobalVariable.basedTopic}/CHECK_PRESSURE_S10_TRACK4" ,

         };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.Publish_Message(10);
        mqtt.SubscribeTopic(topicStation10);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation10);
        mqtt.Publish_Message(0);
    }
}

