using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_12 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation12 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S12/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation12;
        signalR.UpdateTopics(topicStation12);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
