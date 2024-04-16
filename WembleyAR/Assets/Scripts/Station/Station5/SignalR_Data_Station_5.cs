using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_5 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation5 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S5/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation5;
        signalR.UpdateTopics(topicStation5);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
