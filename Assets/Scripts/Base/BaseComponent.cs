using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class BaseComponent : MonoBehaviour
{
    public string Name;
    public BaseComponentTypes Type;
    protected Base Base;
    public bool IsRunning, IsMaintenanceRequired;
    public GameObject IndicationLight;
    public IndicationLightModes IndicationLightMode;
    public Animator IndicationLightAnimator;
    public double EnergyConsumption, EnergyProduction, FuelConsumption, MaintenanceModifier;
    public int MaintenanceInterval, Condition;
    public Canvas InteractionMenu;

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
        Door,
        Solarpanel
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

    public void SetBase(Base Base)
    {
        this.Base = Base;
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
            InteractionMenu.GetComponentInChildren<Text>().text = Name;
            InteractionMenu.GetComponent<CanvasGroup>().alpha = 1;
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
