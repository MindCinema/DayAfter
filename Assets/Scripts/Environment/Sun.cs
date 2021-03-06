﻿using UnityEngine;
using System.Collections;
using System;

public class Sun : MonoBehaviour
{

    private const float rotation = 0.25f;
    // Use this for initialization
    void Start()
    {
        var rotationCorrection = -90 + (GameTime.DateTime.TimeOfDay.TotalMinutes * rotation);
        if (Gamemode.DebugMode)
        {
            Debug.Log(GameTime.DateTime.TimeOfDay.TotalMinutes);
        }
        if (Gamemode.DebugMode)
        {
            Debug.Log(rotationCorrection);
        }
        transform.rotation = Quaternion.Euler((float)rotationCorrection, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotation * Time.deltaTime);
    }

    public bool IsUp()
    {
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " rotation x " + transform.rotation.eulerAngles.x);
            Debug.Log(name + " is shining " + (transform.rotation.eulerAngles.x >= 0 && transform.rotation.eulerAngles.x <= 90));
        }
        return (transform.rotation.eulerAngles.x >= 0 && transform.rotation.eulerAngles.x <= 90);
    }

    public bool IsShiningOn(Vector3 position)
    {
        return Physics.Raycast(transform.position, position);
    }
}
