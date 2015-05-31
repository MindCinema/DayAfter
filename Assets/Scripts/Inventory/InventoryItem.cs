using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string Name;
    public double Weight;
    public ItemCategory Category;
    public enum ItemCategory
    {
        Bag
    }
}
