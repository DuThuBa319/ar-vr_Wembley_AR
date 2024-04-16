using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_7 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation7 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S7/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation7;
        signalR.UpdateTopics(topicStation7);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
