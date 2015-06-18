using UnityEngine;
using System.Collections.Generic;

public class BaseLight : BaseComponent
{
    public int EnergyConsumption;
    public List<GameObject> LightSources;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool Action()
    {
        if (BaseHasEnoughEnergy(EnergyConsumption))
        {
            if (IsRunning)
            {
                UseEnergy(EnergyConsumption);
                EnableLights();
            } else
            {
                DisableLights();
            }
            return true;
        }
        else
        {
            DisableLights();
            return false;
        }
    }

    private void EnableLights()
    {
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " enabling LightSources " + LightSources);
        }
        foreach (var light in LightSources)
        {
            if (Gamemode.DebugMode)
            {
                Debug.Log(name + " enabling " + light);
            }
            light.SetActive(true);
        }
    }

    private void DisableLights()
    {
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " disabling LightSources " + LightSources);
        }
        foreach (var light in LightSources)
        {
            if (Gamemode.DebugMode)
            {
                Debug.Log(name + " disabling " + light);
            }
            light.SetActive(false);
        }
    }
}
