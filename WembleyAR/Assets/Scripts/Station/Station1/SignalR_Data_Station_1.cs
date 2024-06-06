using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_1 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation1 = new List<string>  {
         $"{GlobalVariable.basedTopic}/S1/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        GlobalVariable.subscribedTopics.AddRange(topicStation1);
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(1);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(0);
    }
}
