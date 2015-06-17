using UnityEngine;
using System.Collections;
using System.Globalization;
using System;

public class Gamemode : MonoBehaviour
{
    //public int Year, Month, Day, Hour, Minute, Second, Acceleration;
    private DateTime GameTime;
    public GameObject Sun;
    private const float rotation = 0.25f;

    // Use this for initialization
    void Start()
    {
        Debug.Log(rotation);
        GameTime = new DateTime(2040, 6, 1, 12, 0, 0);
        var rotationCorrection = -90 + (GameTime.TimeOfDay.TotalMinutes * rotation);
        Debug.Log(GameTime.TimeOfDay.TotalMinutes);
        Debug.Log(rotationCorrection);
        Sun.transform.rotation = Quaternion.Euler((float)rotationCorrection, 90, 0);
        InvokeRepeating("UpdateTime", 1, 1);
    }

    private void UpdateTime()
    {
        GameTime = GameTime.AddMinutes(1);
    }

    // Update is called once per frame
    void Update()
    {
        Sun.transform.Rotate(Vector3.right, rotation * Time.deltaTime);
    }
}
