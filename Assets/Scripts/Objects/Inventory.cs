using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> Items;

    public int MaxWeight
    {
        get;
        set;
    }

    public double Weight
    {
        get
        {
            return Items.Sum(item => item.Weight);
        }
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    public bool AddItem(Item Item)
    {
        double itemWeight = Item.Weight;
        if (MaxWeight - Weight < itemWeight)
        {
            return false;
        }
        Items.Add(Item);
        return true;
    }

    public void RemoveItem(Item Item)
    {
        Items.Remove(Item);
    }   
}
