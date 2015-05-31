using UnityEngine;
using System.Collections;

public class BaseComponent : MonoBehaviour
{
    public string Name;
    public BaseComponentTypes Type;
    public Base Base;
    public int EnergyChange;

    public enum BaseComponentTypes
    {
        Empty,
        Generator,
        Light
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleEnergy()
    {
        Base.ModifyEnergy(EnergyChange);
    }
}
