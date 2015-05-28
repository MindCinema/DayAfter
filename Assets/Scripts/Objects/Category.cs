using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Category : MonoBehaviour
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
}
