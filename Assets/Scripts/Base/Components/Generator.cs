using UnityEngine;
using System.Collections;

public class Generator : BaseComponent
{
    public int EnergyProduction;
    public int FuelConsumption;
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
        return true;
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
