using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract int Id
    {
        get;
    }

    public abstract string Name
    {
        get;
        set;
    }

    public abstract double Weight
    {
        get;
        set;
    }

    public abstract Category Category
    {
        get;
        set;
    }
}
