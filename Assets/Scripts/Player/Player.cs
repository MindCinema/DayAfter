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
    public int Health;
    private bool IsInBuilding = false;
    private GameObject Building = null;

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
        var newCameraDistance = CameraDistance - (Input.GetAxis("Mouse ScrollWheel") * 4);
        if (newCameraDistance > 10) newCameraDistance = 10;
        if (newCameraDistance < 5) newCameraDistance = 5;
        CameraDistance = newCameraDistance;
        var pos = gameObject.transform.position;
        pos.y = pos.y + CameraDistance;
        pos.z = pos.z - (CameraDistance / 2);
        PlayerCamera.transform.position = pos;
        if (IsInBuilding)
        {
            foreach (Transform child in Building.transform)
            {
                if (child.tag.Equals("Floor"))
                {
                    if (child.position.y > gameObject.transform.position.y)
                    {
                        var renderer = child.GetComponent<Renderer>();
                        renderer.enabled = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Building"))
        {
            EnterBuilding(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Building"))
        {
            LeaveBuilding(other.gameObject);
        }
    }

    private void EnterBuilding(GameObject building)
    {
        IsInBuilding = true;
        Building = building;
        foreach (Transform child in building.transform)
        {
            if (child.tag.Equals("Roof"))
            {
                var renderer = child.GetComponent<Renderer>();
                renderer.enabled = false;
            }
        }
    }

    private void LeaveBuilding(GameObject building)
    {
        IsInBuilding = false;
        Building = null;
        foreach (Transform child in building.transform)
        {
            var renderer = child.GetComponent<Renderer>();
            renderer.enabled = true;
        }
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
