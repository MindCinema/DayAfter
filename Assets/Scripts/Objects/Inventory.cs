using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> Items;
    private GameObject Canvas;

    public int MaxWeight;

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
        Canvas = GameObject.Find("Canvas");
    }

    private void Update()
    {
        if (Input.GetButton("Inventory"))
        {
            Debug.Log("Inventory");
        }
        var image = Canvas.GetComponentInChildren<Image>();
        if (IsBoxNearPlayer())
        {
            Debug.Log("Bild zeigen");
            image.CrossFadeAlpha(1, 0, true);
        }
        else
        {
            Debug.Log("Bild verstecken");
            image.CrossFadeAlpha(0, 0, true);
        }
    }

    private void OnMouseDown()
    {
        if (IsBoxNearPlayer())
        {
            Debug.Log("Inventar auf");
        }
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

    private bool IsBoxNearPlayer()
    {
        var player = GameObject.Find("Player");
        if (player != null)
        {
            var playerPos = player.transform.position;
            var boxPos = gameObject.transform.position;
            var distance = Vector3.Distance(playerPos, boxPos);
            if (distance < 5)
            {
                return true;
            }
        }
        return false;
    }
}
