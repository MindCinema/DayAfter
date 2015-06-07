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
        foreach (var light in LightSources)
        {
            light.SetActive(true);
        }
    }

    private void DisableLights()
    {
        foreach (var light in LightSources)
        {
            light.SetActive(false);
        }
    }
}
