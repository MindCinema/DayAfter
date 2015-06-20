using UnityEngine;
using System.Collections;

public abstract class BaseComponent : MonoBehaviour
{
    public string Name;
    public BaseComponentTypes Type;
    public Base Base;
    public bool IsRunning;
    public GameObject IndicationLight;
    public IndicationLightModes IndicationLightMode;
    public Animator IndicationLightAnimator;

    public enum IndicationLightModes
    {
        Glow,
        Animation
    }

    public enum BaseComponentTypes
    {
        None,
        Generator,
        Light,
        Door
    }

    // Use this for initialization
    void Start()
    {
        if (IndicationLight != null)
        {
            IndicationLight.SetActive(IsRunning);
            if (IndicationLightMode == IndicationLightModes.Animation)
            {
                IndicationLightAnimator.enabled = IsRunning;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " OnMouseDown");
        }
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 1)
            {
                Use();
            }
            else if (Gamemode.DebugMode)
            {
                Debug.Log(name + " player too far away for use");
            }
        }
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
        }
        else
        {
            return false;
        }
    }

    public abstract bool Action();
    public virtual void Use()
    {
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " use action");
        }
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " is running " + IsRunning + " + set to " + !IsRunning);
        }
        IsRunning = !IsRunning;
        if (IndicationLight != null)
        {
            IndicationLight.SetActive(IsRunning);
            if (IndicationLightMode == IndicationLightModes.Animation)
            {
                IndicationLightAnimator.enabled = IsRunning;
            }
        }
    }
}
