using System;
using System.Threading;
using Unity.Jobs;
using UnityEngine;

public struct Job : IJob
{
    Action work;
    public Job(Action work)
    {
        this.work = work;
    }
    public void Execute()
    {
        work?.Invoke();
    }
}
