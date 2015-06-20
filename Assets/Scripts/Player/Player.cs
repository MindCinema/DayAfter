using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{

    public Image InventoryImage;
    public Canvas InventoryCanvas;
    private List<GameObject> InventoryObjects;
    public Camera PlayerCamera;
    private float CameraDistance = 8;

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
            }
            else
            {
                InventoryCanvas.gameObject.SetActive(false);
            }
        }
        var newCameraDistance = CameraDistance - Input.GetAxis("Mouse ScrollWheel");
        if (newCameraDistance > 10) newCameraDistance = 10;
        if (newCameraDistance < 5) newCameraDistance = 5;
        CameraDistance = newCameraDistance;
        var pos = gameObject.transform.position;
        if (Gamemode.DebugMode)
        {
            Debug.Log(name + " playerPos " + pos);
        }
        pos.y = pos.y + CameraDistance;
        pos.z = pos.z - (CameraDistance / 2);
        PlayerCamera.transform.position = pos;


    }

    private void FixedUpdate()
    {
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
