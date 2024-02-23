using System;
using UnityEngine;

[Serializable]
public class Timer
{
    /// <summary>
    /// Whether the timer is currently running or not
    /// </summary>
    [field: SerializeField] public bool Running { get; private set; }

    /// <summary>
    /// The total time duration for the timer
    /// </summary>
    [SerializeField] float releaseTime;

    /// <summary>
    /// The elapsed time since the timer started running
    /// </summary>
    [SerializeField] float runningTime;

    /// <summary>
    /// Event invoked when the timer is started
    /// </summary>
    public event Action TimerStarted;

    /// <summary>
    /// Event invoked when the timer is played (started or resumed)
    /// </summary>
    public event Action TimerPlayed;

    /// <summary>
    /// Event invoked when the timer is paused
    /// </summary>
    public event Action TimerPaused;

    /// <summary>
    /// Event invoked when the timer ends
    /// </summary>
    public event Action TimerEnded;

    /// <summary>
    /// Event invoked when the timer is running (updated)
    /// </summary>
    public event Action TimerRunning;

    /// <summary>
    /// Event invoked when the timer is reset
    /// </summary>
    public event Action TimerReset;

    /// <summary>
    /// Constructor for the Timer class
    /// </summary>
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

    /// <summary>
    /// Reset the timer to its initial state
    /// </summary>
    public void Reset()
    {
        releaseTime = 0;
        ResetProgress();
        TimerReset?.Invoke();
    }

    /// <summary>
    /// Start or resume the timer
    /// </summary>
    public void Play()
    {
        Running = true;
        TimerPlayed?.Invoke();
    }

    /// <summary>
    /// Pause the timer
    /// </summary>
    public void Pause()
    {
        Running = false;
        TimerPaused?.Invoke();
    }

    /// <summary>
    /// Initialize the timer with the specified release time and start it
    /// </summary>
    /// <param name="releaseTime"></param>
    public void Begin(float releaseTime)
    {
        Reset();
        this.releaseTime = releaseTime;
        Play();
        TimerStarted?.Invoke();
    }

    /// <summary>
    /// Reset the timer's progress to zero
    /// </summary>
    public void ResetProgress()
    {
        runningTime = 0;
        Running = false;
    }

    /// <summary>
    /// Manually set the progress of the timer in seconds
    /// </summary>
    /// <param name="seconds"></param>
    public void SetProgress(float seconds)
    {
        runningTime = seconds;
    }

    /// <summary>
    /// Manually set the progress of the timer as a percentage
    /// </summary>
    /// <param name="percentage"></param>
    public void SetProgressPercentage(float percentage)
    {
        runningTime = releaseTime * (percentage / 100);
    }

    /// <summary>
    /// Check if the timer has reached its end
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return runningTime > releaseTime;
    }

    /// <summary>
    /// Update the timer's running time, invoke events, and check for timer completion.
    /// Ensure to call Timer's Update method in Unity's Update() method to update the timer.
    /// </summary>
    public void Update()
    {
        if (!Running) { return; }
        runningTime += Time.deltaTime;
        if (IsEnd()) { TimerEnded?.Invoke(); }
        TimerRunning?.Invoke();
    }
}