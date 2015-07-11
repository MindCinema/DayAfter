using UnityEngine;
using System.Collections;

public class Generator : BaseComponent
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool HasFuel()
    {
        return Base.UseFuel(FuelConsumption);
    }

    public override bool Action()
    {
        if (HasFuel() && IsRunning)
        {
            var energy = Base.Energy + EnergyProduction;
            if (energy > Base.MaxEnergy)
            {
                Base.Energy = Base.MaxEnergy;
            }
            else
            {
                Base.Energy = energy;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
