using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCanceller : MonoBehaviour
{
    public Delayer delayer;

    public void OnApplicationQuit()
    {
        int num = 0;
        for (int i = 0; i < delayer.cancellationTokenSources.Count; i++)
        {
            delayer.cancellationTokenSources[i].Cancel();
            num = i;
        }
        Debug.Log("tasks cancelled: " + num);
    }
}