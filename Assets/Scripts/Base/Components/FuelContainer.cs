using UnityEngine;
using System.Collections;

public class FuelContainer : BaseComponent
{
    public double Capacity;

    // Use this for initialization
    void Start()
    {
        Base.MaxFuel += Capacity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool Action()
    {
        //Nothing to do here
        return true;
    }
}
