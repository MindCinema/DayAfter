using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> Items;

    public int MaxWeight;
    public float Radius;

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
        var inventoryCollider = gameObject.AddComponent<SphereCollider>();
        if (Radius == 0)
        {
            inventoryCollider.radius = 3;
        } else
        {
            inventoryCollider.radius = Radius;
        }
        inventoryCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SendMessage("InventoryRangeEntered", this.gameObject);
    }

    private void OnTriggerExit(Collider collider)
    {
        collider.gameObject.SendMessage("InventoryRangeLeft", this.gameObject);
    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {
    }

    private void OnMouseOver()
    {
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
