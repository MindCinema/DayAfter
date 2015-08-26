using UnityEngine;
using System.Collections;

public class Solarpanel : BaseComponent
{
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
        if (GameEnvironment.Sun.IsShiningOn(transform.position))
        {
            Base.AddEnergy(EnergyProduction);
            return true;
        }
        else
        {
            return false;
        }
    }
}
