using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;

public class Player : MonoBehaviour
{
    private List<GameObject> InventoryObjects = new List<GameObject>();
    public Camera PlayerCamera;
    private float CameraDistance = 8;
    public int Health;
    private bool IsInBuilding = false;
    private GameObject Building = null;
    private Vector3 PlayerPos
    {
        get
        {
            var collider = gameObject.GetComponent<CharacterController>();
            return collider.transform.position + collider.center;
        }
    }
    private Vector3 CameraPos
    {
        get
        {
            return PlayerCamera.transform.position;
        }
    }
    private RaycastHit LinecastHit;
    private List<Collider> HiddenObjects = new List<Collider>();
    private List<Collider> ObjectsToHide = new List<Collider>();

    // Use this for initialization
    private void Start()
    {
    }

    private void FixedUpdate()
    {
    }

    private void Move(float move, float turn, bool run)
    {
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, turn * 3.0f, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float moveSpeed, moveAnimSpeed;
        if (run)
        {
            moveSpeed = move * 6.0f - Math.Abs(turn * 2);
            moveAnimSpeed = 1.0f;
        }
        else
        {
            moveSpeed = move * 2.0f;
            moveAnimSpeed = 0.56f;
        }
        controller.SimpleMove(forward * moveSpeed);
        if (controller.isGrounded)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetFloat("Forward", moveAnimSpeed * move, 0.1f, Time.deltaTime);
            animator.SetFloat("Turn", turn, 0.1f, Time.deltaTime);
        }
        MoveCamera();
    }

    private void HideObjects()
    {
        if (Physics.Linecast(CameraPos, PlayerPos, out LinecastHit))
        {
            ObjectsToHide.Add(LinecastHit.collider);
        }

        foreach (var objectToShow in HiddenObjects.Except<Collider>(ObjectsToHide))
        {
            var renderer = objectToShow.gameObject.GetComponent<Renderer>();
            renderer.enabled = true;
        }

        foreach (var objectToHide in ObjectsToHide)
        {
            var renderer = objectToHide.gameObject.GetComponent<Renderer>();
            renderer.enabled = false;
            HiddenObjects.Add(objectToHide);
        }

        ObjectsToHide.Clear();
    }

    private void MoveCamera()
    {
        var newCameraDistance = CameraDistance - (Input.GetAxis("Mouse ScrollWheel") * 4);
        if (newCameraDistance > 10) newCameraDistance = 10;
        if (newCameraDistance < 5) newCameraDistance = 5;
        CameraDistance = newCameraDistance;
        var pos = gameObject.transform.position;
        pos.y = pos.y + CameraDistance;
        pos.z = pos.z - (CameraDistance / 2);
        PlayerCamera.transform.position = pos;
    }

    // Update is called once per frame
    private void Update()
    {
        float move = CrossPlatformInputManager.GetAxis("Vertical");
        float turn = CrossPlatformInputManager.GetAxis("Horizontal");
        bool run = Input.GetKey(KeyCode.LeftShift);
        Move(move, turn, run);
        HideObjects();
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
}
