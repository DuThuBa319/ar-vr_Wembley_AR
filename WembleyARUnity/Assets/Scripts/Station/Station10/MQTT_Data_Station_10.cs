using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_10 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation10 = new List<string> {

          "HCM/IE-F2-HCA01/Metric/S10/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/01" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/02" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/03" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/04" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/05" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/05" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/06" ,
         "HCM/IE-F2-HCA01/Metric/S10/in/07" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/01" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/02" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/03" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/04" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/05" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/06" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/07" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/08" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/09" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/10" ,
         "HCM/IE-F2-HCA01/Metric/S10/out/11" , };
    void Start()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
        mqtt.SubscribeTopic(topicStation10);
    }
    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation10);
    }
}

