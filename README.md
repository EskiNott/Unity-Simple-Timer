Here is a README.md for a Unity Simple Timer project based on the provided code:

# Unity Simple Timer

This is a simple timer utility for Unity. It allows you to create and control timer objects in your Unity projects.

## Features

- Create timer objects with a specified duration
- Start, pause, and reset timers
- Get timer progress and check if timer has ended
- Timer events for start, pause, end etc. 
- Different timer modes:
  - Continuous
  - Instant stop 
  - Loop
- Easy to use API

## Usage

### Create a timer

```csharp
Timer myTimer = new Timer();
```

### Initialize timer

Set duration and start timer:

```csharp
myTimer.Begin(10f); // 10 seconds duration
```

Optionally specify timer mode:

```csharp
myTimer.Begin(10f, TimerMode.Loop); 
```

### Control timer

```csharp
myTimer.Play(); // Start or resume
myTimer.Pause(); // Pause
myTimer.Reset(); // Reset
```

### Check timer state

```csharp
float progress = myTimer.Progress(); // Get progress

if(myTimer.IsEnd()) {
  // Timer ended
}

if(myTimer.ReachProgress(5f)) {
  // Reached 5 seconds  
}
```

### Timer events

```csharp
myTimer.TimerStarted += OnTimerStarted;

...

void OnTimerStarted() {
  // Do something
}
```

### Update timer

Call `Update()` method on timer instance:

```csharp
void Update() {
  myTimer.Update();
}
```

## Installation

Simply include the Timer.cs file in your Unity project.

## Contributing

Pull requests are welcome. Feel free to open issues for any enhancements or bugs.