using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Encoder_Position_Subscribe : MonoBehaviour
{
    MQTT mqtt;
    List<string> topic = new List<string> {
          $"{GlobalVariable.basedTopic}/Encoder Value" ,
};
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.Publish_Message(13);
        mqtt.SubscribeTopic(topic);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topic);
        mqtt.Publish_Message(0);
    }
}

