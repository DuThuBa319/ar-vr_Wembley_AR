using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_4 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation4 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S4/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation4;
        signalR.UpdateTopics(topicStation4);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
