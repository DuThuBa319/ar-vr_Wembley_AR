using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_6 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation6 = new List<string> {


         $"{GlobalVariable.basedTopic}/S6/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        GlobalVariable.subscribedTopics.AddRange(topicStation6);
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(6);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(0);
    }
}
