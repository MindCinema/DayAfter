using UnityEngine;
using System.Collections;

public class Solarpanel : BaseComponent {

    public int EnergyProduction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override bool Action()
    {
        if (Gamemode.Sun.IsShining())
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
