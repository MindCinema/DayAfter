using UnityEngine;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    public int MaxComponents;
    public List<BaseComponent> Components;
    public double MaxEnergy;
    public double Energy;
    public double Fuel;
    public double MaxFuel;
    // Use this for initialization
    void Start()
    {
        foreach (var component in Components)
        {
            component.SetBase(this);
        }
        InvokeRepeating("RunActions", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddEnergy(double Amount)
    {
        var newEnergy = Energy + Amount;
        if (newEnergy > MaxEnergy)
        {
            Energy = MaxEnergy;
        } else
        {
            Energy = newEnergy;
        }
    }

    public bool UseEnergy(double Amount)
    {
        var newEnergy = Energy - Amount;
        if (newEnergy < 0)
        {
            Energy = 0;
            return false;
        } else
        {
            Energy = newEnergy;
            return true;
        }
    }

    public bool UseFuel(double Amount)
    {
        var newFuel = Fuel - Amount;
        if (newFuel < 0)
        {
            Fuel = 0;
            return false;
        }
        else
        {
            Fuel = newFuel;
            return true;
        }
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
