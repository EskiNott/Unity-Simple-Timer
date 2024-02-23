# Unity Simple Timer

Unity Simple Timer is a lightweight timer class designed for use in Unity projects. This timer allows you to easily manage timed events, track progress, and execute actions upon timer completion.

## Features

- **Simple Implementation**: Easily integrate timers into your Unity projects with minimal setup.
- **Flexible Usage**: Start, pause, resume, reset, and monitor the progress of timers as needed.
- **Event-driven Design**: Utilizes events to notify when the timer starts, pauses, resumes, ends, and resets, enabling seamless integration with other game components.

## How to Use

1. **Import Timer Class**: Import the `Timer.cs` class into your Unity project.
2. **Instantiate Timer**: Create an instance of the `Timer` class wherever you need to use a timer.
3. **Configure Timer**: Set the release time using the `Begin` method and start the timer with the `Play` method.
4. **Update Timer**: Call the `Update` method in your Unity `Update` loop to update the timer.
5. **Handle Events**: Subscribe to the timer events (`TimerStarted`, `TimerPlayed`, `TimerPaused`, `TimerEnded`, `TimerRunning`, `TimerReset`) to execute custom actions based on timer states.

## Example

```csharp
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    Timer timer;

    void Start()
    {
        timer = new Timer();
        timer.TimerEnded += OnTimerEnd;
        timer.Begin(10f); // Start a timer with 10 seconds
    }

    void Update()
    {
        timer.Update();
    }

    void OnTimerEnd()
    {
        Debug.Log("Timer ended!");
    }
}
```
