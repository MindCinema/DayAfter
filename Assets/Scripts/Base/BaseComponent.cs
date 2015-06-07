using UnityEngine;
using System.Collections;

public abstract class BaseComponent : MonoBehaviour
{
    public string Name;
    public BaseComponentTypes Type;
    public Base Base;
    public bool IsRunning;

    public enum BaseComponentTypes
    {
        Empty,
        Generator,
        Light,
        Door
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }

    void OnMouseDown()
    {
        Use();
    }

    protected void UseEnergy(int amount)
    {
        Base.Energy -= amount;
    }

    protected bool BaseHasEnoughEnergy(int amount)
    {
        if (Base.Energy - amount >= 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public abstract bool Action();
    public virtual void Use()
    {
        IsRunning = !IsRunning;
    }
}
