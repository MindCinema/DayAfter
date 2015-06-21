using UnityEngine;
using System.Collections;
using System.Globalization;
using System;

public class Gamemode : MonoBehaviour
{
    //public int Year, Month, Day, Hour, Minute, Second, Acceleration;
    public static DateTime GameTime;
    public static bool DebugMode = true;
    public static Sun Sun;
    public int StartYear, StartMonth, StartDay, StartHour, StartMinute;

    void Awake()
    {
        GameTime = new DateTime(StartYear, StartMonth, StartDay, StartHour, StartMinute, 0);
        Sun = GameObject.FindObjectOfType<Sun>();
        Debug.Log(Sun);
    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTime", 1, 1);
    }

    private void UpdateTime()
    {
        GameTime = GameTime.AddMinutes(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
