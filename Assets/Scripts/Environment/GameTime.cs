using UnityEngine;
using System.Collections;
using System;

public class GameTime : MonoBehaviour
{
    public int StartYear, StartMonth, StartDay, StartHour, StartMinute;
    public static DateTime DateTime;

    int currentDay, currentHour, currentMinute;

    // Use this for initialization
    void Start()
    {
        DateTime = new DateTime(StartYear, StartMonth, StartDay, StartHour, StartMinute, 0);
        InvokeRepeating("UpdateTime", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateTime()
    {
        DateTime = DateTime.AddMinutes(1);
        if (DateTime.DayOfYear != currentDay)
        {
            NotifyDayChanged();
        }
        if (DateTime.Hour != currentHour)
        {
            NotifyHourChanged();
        }
        NotifyMinuteChanged();
    }

    void NotifyDayChanged()
    {
        var eventArgs = new DayChangedEventArgs();
        eventArgs.NewDay = DateTime.DayOfYear;
        eventArgs.OldDay = currentDay;
        DayChanged(this, eventArgs);
        currentDay = DateTime.DayOfYear;
    }

    void NotifyHourChanged()
    {
        var eventArgs = new HourChangedEventArgs();
        eventArgs.NewHour = DateTime.Hour;
        eventArgs.OldHour = currentHour;
        HourChanged(this, eventArgs);
        currentHour = DateTime.Hour;
    }

    void NotifyMinuteChanged()
    {
        var eventArgs = new MinuteChangedEventArgs();
        eventArgs.NewMinute = DateTime.Minute;
        eventArgs.OldMinute = currentMinute;
        MinuteChanged(this, eventArgs);
        currentMinute = DateTime.Minute;
    }

    public static event DayChangedEventHandler DayChanged;
    public static event HourChangedEventHandler HourChanged;
    public static event MinuteChangedEventHandler MinuteChanged;

    public delegate void DayChangedEventHandler(GameTime sender, DayChangedEventArgs e);
    public delegate void HourChangedEventHandler(GameTime sender, HourChangedEventArgs e);
    public delegate void MinuteChangedEventHandler(GameTime sender, MinuteChangedEventArgs e);
}

public class DayChangedEventArgs : EventArgs
{
    public int OldDay { get; set; }
    public int NewDay { get; set; }
}

public class HourChangedEventArgs : EventArgs
{
    public int OldHour { get; set; }
    public int NewHour { get; set; }
}

public class MinuteChangedEventArgs : EventArgs
{
    public int OldMinute { get; set; }
    public int NewMinute { get; set; }
}