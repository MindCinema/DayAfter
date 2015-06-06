using UnityEngine;
using System.Collections;

public abstract class BaseComponent : MonoBehaviour
{
    public string Name;
    public BaseComponentTypes Type;
    public Base Base;

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

    public abstract bool Action();
    public abstract bool Use();
}
