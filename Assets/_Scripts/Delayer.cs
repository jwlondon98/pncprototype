using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Custom delay to allow for passing by ref
/// </summary>
public class Delayer : MonoBehaviour
{
    public bool boolState;
    public List<System.Threading.CancellationTokenSource> cancellationTokenSources = new List<System.Threading.CancellationTokenSource>();

    private DelayCanceller delayCanceller;

    private void Awake()
    {
        // TODO = WORK ON THIS to happen automatically
        delayCanceller = new GameObject().AddComponent<DelayCanceller>();
    }

    public async Task WaitForSeconds(double delayLength)
    {
        boolState = !boolState;

        var tokenSource = new System.Threading.CancellationTokenSource();
        tokenSource.Token.ThrowIfCancellationRequested();
        cancellationTokenSources.Add(tokenSource);

        //Debug.Log("cancellation token count: " + cancellationTokenSources.Count);

        await Task.Delay(TimeSpan.FromSeconds(delayLength), tokenSource.Token);

        boolState = !boolState;
    }

    public async Task WaitForMinutes(double delayLength)
    {
        boolState = !boolState;

        var tokenSource = new System.Threading.CancellationTokenSource();
        tokenSource.Token.ThrowIfCancellationRequested();
        cancellationTokenSources.Add(tokenSource);

        await Task.Delay(TimeSpan.FromMinutes(delayLength), tokenSource.Token);

        boolState = !boolState;
    }
}