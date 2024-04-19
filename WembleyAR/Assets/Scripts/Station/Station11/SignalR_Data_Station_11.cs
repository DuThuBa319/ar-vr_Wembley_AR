using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_11 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation11 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S11/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation11;
        signalR.UpdateTopics(topicStation11);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}