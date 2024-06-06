using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_7 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation7 = new List<string> {

         $"{GlobalVariable.basedTopic}/S7/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        GlobalVariable.subscribedTopics.AddRange(topicStation7);
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(7);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(0);
    }
}
