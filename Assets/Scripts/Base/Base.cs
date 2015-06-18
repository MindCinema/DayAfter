﻿using UnityEngine;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    public int MaxComponents;
    public List<BaseComponent> Components;
    public int MaxEnergy;
    public int Energy;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("RunActions", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RunActions()
    {
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " BaseComponents: " + Components);
        }
        foreach (var component in Components)
        {
            if (Gamemode.DebugMode)
            {
                Debug.Log("Aktion von Komponente " + component.name);
            }
            component.Action();
        }
    }
}
