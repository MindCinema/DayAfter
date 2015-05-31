using UnityEngine;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    public int MaxComponents;
    public BaseComponent[] components;
    public int MaxEnergy;
    private int energy;
    // Use this for initialization
    void Start()
    {
        components = new BaseComponent[MaxComponents];
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("UpdateEnergy", 1.0f, 1.0f);
    }

    public void UpdateEnergy(int Amount)
    {
        foreach (var component in components)
        {
            component.HandleEnergy();
        }
    }

    public void ModifyEnergy(int Amount)
    {
        var result = energy + Amount;
        if (result > MaxEnergy)
        {
            energy = MaxEnergy;
        }
        else if (result < 0)
        {
            energy = 0;
        }
        else
        {
            energy = 0;
        }
    }
}
