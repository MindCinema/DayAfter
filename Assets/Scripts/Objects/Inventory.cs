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
        Items = new List<Item>();
    }

    private void Update()
    {
    }

    private void OnMouseDown()
    {
        Debug.Log("Klick!");
        var player = GameObject.Find("Player");
        if (player != null)
        {
            var playerPos = player.transform.position;
            var boxPos = gameObject.transform.position;
            var distance = Vector3.Distance(playerPos, boxPos);
            if (distance < 5)
            {
                Debug.Log("Inventar auf");
            }
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse over");
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
