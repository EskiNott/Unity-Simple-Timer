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
    /// Get the progress of the timer.
    /// </summary>
    /// <returns>Representing the normalized time in float.</returns>
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
    /// Check if the timer has reached a certain progress.
    /// </summary>
    /// <param name="Time">The time to check against.</param>
    /// <returns>True if the timer has reached the specified time, false otherwise.</returns>
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

    // Ensure to call Timer's Update method in Unity's Update() method to update the timer.
    public void Update()
    {
        if (!Running) { return; }
        runningTime += Time.deltaTime;
        if (IsEnd()) { TimerEnded?.Invoke(); }
        TimerRunning?.Invoke();
    }

}
