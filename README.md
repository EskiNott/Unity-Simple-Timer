# Simple Timer

The Timer is a utility class for managing time-related operations in Unity. It provides functionality for starting, pausing, resuming, and resetting timers, as well as events for handling various timer states.

## Usage

1. **Create Timer Instance**: You can create an instance of the Timer class using the constructor.

    ```csharp
    Timer timer = new Timer();
    ```

2. **Start Timer**: To start the timer, use the `Begin` method and specify the release time.

    ```csharp
    timer.Begin(10f); // Starts the timer with a release time of 10 seconds
    ```

3. **Pause Timer**: To pause the timer, use the `Pause` method.

    ```csharp
    timer.Pause();
    ```

4. **Resume Timer**: To resume the timer after pausing, use the `Play` method.

    ```csharp
    timer.Play();
    ```

5. **Reset Timer**: To reset the timer, use the `Reset` method.

    ```csharp
    timer.Reset();
    ```

6. **Check Timer Progress**: You can check the progress of the timer using the `Progress` method, which returns the normalized time.

    ```csharp
    float progress = timer.Progress();
    ```

7. **Check if Timer is Ended**: To check if the timer has reached its end, use the `IsEnd` method.

    ```csharp
    bool isEnd = timer.IsEnd();
    ```

## Events

The Timer class provides events to handle different timer states:

- `TimerStarted`: Triggered when the timer is started.
- `TimerPlayed`: Triggered when the timer is played (resumed).
- `TimerPaused`: Triggered when the timer is paused.
- `TimerEnded`: Triggered when the timer reaches its end.
- `TimerRunning`: Triggered continuously while the timer is running.
- `TimerReset`: Triggered when the timer is reset.

You can subscribe to these events to execute custom logic based on the timer state.

## Example

```csharp
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    private Timer timer;

    private void Start()
    {
        timer = new Timer();
        timer.TimerStarted += OnTimerStarted;
        timer.TimerPaused += OnTimerPaused;
        timer.TimerPlayed += OnTimerPlayed;
        timer.TimerEnded += OnTimerEnded;
        timer.TimerRunning += OnTimerRunning;
        timer.TimerReset += OnTimerReset;
    }

    private void Update()
    {
        timer.Update();
    }

    private void OnTimerStarted()
    {
        Debug.Log("Timer started!");
    }

    private void OnTimerPaused()
    {
        Debug.Log("Timer paused!");
    }

    private void OnTimerPlayed()
    {
        Debug.Log("Timer played!");
    }

    private void OnTimerEnded()
    {
        Debug.Log("Timer ended!");
    }

    private void OnTimerRunning()
    {
        Debug.Log("Timer is running...");
    }

    private void OnTimerReset()
    {
        Debug.Log("Timer reset!");
    }
}
```
This example demonstrates how to use the Timer class and handle its events.