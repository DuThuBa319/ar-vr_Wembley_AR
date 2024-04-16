using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_6 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation6 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S6/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation6;
        signalR.UpdateTopics(topicStation6);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
