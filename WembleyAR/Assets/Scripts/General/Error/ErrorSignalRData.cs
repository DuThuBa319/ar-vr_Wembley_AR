using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorSignalRData : MonoBehaviour
{
    SignalRData signalR;
    List<string> errorTopics = new List<string> {
         $"{GlobalVariable.basedTopic}/errorStatus" ,
          };

    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }

    void OnEnable()
    {
        GlobalVariable.subscribedTopics = errorTopics;
        signalR.UpdateTopics(errorTopics);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}