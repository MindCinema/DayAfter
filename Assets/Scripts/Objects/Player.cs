﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

    public Image InventoryImage;
    public Canvas InventoryCanvas;
    private List<GameObject> InventoryObjects;

    // Use this for initialization
    private void Start()
    {
        InventoryObjects = new List<GameObject>();
        InventoryCanvas.gameObject.SetActive(false);
        InventoryImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!InventoryCanvas.gameObject.activeSelf)
            {
                InventoryCanvas.gameObject.SetActive(true);
            } else
            {
                InventoryCanvas.gameObject.SetActive(false);
            }
        }
    }

    private void InventoryRangeEntered(GameObject inventoryObject)
    {
        InventoryObjects.Add(inventoryObject);
        InventoryImage.gameObject.SetActive(true);
    }

    private void InventoryRangeLeft(GameObject inventoryObject)
    {
        InventoryObjects.Remove(inventoryObject);
        if (InventoryObjects.Count == 0)
        {
            InventoryImage.gameObject.SetActive(false);
        }
    }
}
