using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_4 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation4 = new List<string> {
         $"{GlobalVariable.basedTopic}/Encoder Value" ,
 $"{GlobalVariable.basedTopic}/S4/in/00" ,
         $"{GlobalVariable.basedTopic}/S4/in/01" ,
         $"{GlobalVariable.basedTopic}/S4/in/02" ,
         $"{GlobalVariable.basedTopic}/S4/in/03" ,
         $"{GlobalVariable.basedTopic}/S4/in/04" ,
         $"{GlobalVariable.basedTopic}/S4/in/05" ,
         $"{GlobalVariable.basedTopic}/S4/in/06" ,
         $"{GlobalVariable.basedTopic}/S4/in/07" ,
         $"{GlobalVariable.basedTopic}/S4/in/08" ,
         $"{GlobalVariable.basedTopic}/S4/in/09" ,
         $"{GlobalVariable.basedTopic}/S4/out/00" ,
         $"{GlobalVariable.basedTopic}/S4/out/01" ,
         $"{GlobalVariable.basedTopic}/S4/out/02" ,
         $"{GlobalVariable.basedTopic}/S4/out/03" ,
         $"{GlobalVariable.basedTopic}/S4/out/04" ,
         $"{GlobalVariable.basedTopic}/S4/out/05" ,
         $"{GlobalVariable.basedTopic}/S4/out/06" ,
         $"{GlobalVariable.basedTopic}/S4/out/07" ,
         $"{GlobalVariable.basedTopic}/S4/out/08" ,
         $"{GlobalVariable.basedTopic}/S4/out/09" ,
         $"{GlobalVariable.basedTopic}/S4/out/10" ,
         $"{GlobalVariable.basedTopic}/S4/out/11" ,
         $"{GlobalVariable.basedTopic}/S4/out/12" ,
         $"{GlobalVariable.basedTopic}/S4/out/13" ,
         $"{GlobalVariable.basedTopic}/S4/out/14" ,
         $"{GlobalVariable.basedTopic}/S4/out/15" ,
         $"{GlobalVariable.basedTopic}/S4/out/16" ,
         $"{GlobalVariable.basedTopic}/S4/out/17" ,
         $"{GlobalVariable.basedTopic}/S4/out/18" ,
         $"{GlobalVariable.basedTopic}/S4/out/19" ,
         $"{GlobalVariable.basedTopic}/S4/out/20" ,
         $"{GlobalVariable.basedTopic}/S4/out/21" ,
         $"{GlobalVariable.basedTopic}/S4/out/22" ,
         $"{GlobalVariable.basedTopic}/S4/out/23" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation4);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation4);
    }
}

