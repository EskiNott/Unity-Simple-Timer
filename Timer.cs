using System;
using UnityEngine;

[Serializable]
public class Timer
{
    [field: SerializeField] public bool Running { get; private set; }
    [SerializeField] float releaseTime;
    [SerializeField] float runningTime;
    public event Action TimerStarted;
    public event Action TimerPlayed;
    public event Action TimerPaused;
    public event Action TimerEnded;
    public event Action TimerRunning;
    public event Action TimerReset;

    public Timer()
    {
        Running = false;
        releaseTime = 0;
        runningTime = 0;
    }

    /// <summary>
    /// 计时器计时进度
    /// </summary>
    /// <returns>Float Normalized Time</returns>
    public float Progress()
    {
        if (releaseTime != 0 && runningTime != 0)
        {
            return runningTime / releaseTime;
        }
        else
        {
            return 0;
        }

    }

    /// <summary>
    /// 计时器进度检测
    /// </summary>
    /// <param name="Time">需要检测的时间</param>
    /// <returns>计时器是否已经达到目标时间</returns>
    public bool ReachProgress(float Time)
    {
        return runningTime > Time;
    }

    public void Reset()
    {
        releaseTime = 0;
        runningTime = 0;
        Running = false;
        TimerReset?.Invoke();
    }

    public void Play()
    {
        Running = true;
        TimerPlayed?.Invoke();
    }

    public void Pause()
    {
        Running = false;
        TimerPaused?.Invoke();
    }

    public void Begin(float releaseTime)
    {
        Reset();
        this.releaseTime = releaseTime;
        Play();
        TimerStarted?.Invoke();
    }

    public bool IsEnd()
    {
        return runningTime > releaseTime;
    }

    public void Update()
    {
        if (Running)
        {
            runningTime += Time.deltaTime;
            if (IsEnd()) { TimerEnded?.Invoke(); }
            TimerRunning?.Invoke();
        }
    }

}
