using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;
using UnityEngine.Networking;
using System.Text;

public class Player : NetworkBehaviour
{
    private List<GameObject> InventoryObjects = new List<GameObject>();
    private float CameraDistance = 60;
    public int Health;
    public float Temperature;
    private bool IsInBuilding = false;
    private GameObject Building = null;
    private Vector3 PlayerPos
    {
        get
        {
            var collider = gameObject.GetComponent<CharacterController>();
            return collider.transform.position + (collider.center * collider.GetComponent<Transform>().localScale.y);
        }
    }
    private Vector3 CameraPos
    {
        get
        {
            return Camera.main.transform.position;
        }
    }
    private RaycastHit LinecastHit;
    private List<GameObject> HiddenObjects = new List<GameObject>();

    // Use this for initialization
    private void Start()
    {
    }

    private void FixedUpdate()
    {
    }

    private void Move(float move, float turn, bool run)
    {
        if (move < 0)
        {
            move = 0;
        }
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, turn * 3.0f, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float moveSpeed, moveAnimSpeed;
        if (run)
        {
            moveSpeed = move * 45.0f - Math.Abs(turn * 15);
            moveAnimSpeed = 1.0f;
        }
        else
        {
            moveSpeed = move * 15.0f - Math.Abs(turn * 5);
            moveAnimSpeed = 0.56f;
        }
        controller.SimpleMove(forward * moveSpeed);
        if (controller.isGrounded)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetFloat("Forward", moveAnimSpeed * move, 0.1f, Time.deltaTime);
            animator.SetFloat("Turn", turn, 0.1f, Time.deltaTime);
        }
        else
        {
            controller.Move(Vector3.down);
        }
        MoveCamera();
    }

    private void HideObjects()
    {
        var direction = PlayerPos - CameraPos;
        var distance = Vector3.Distance(PlayerPos, CameraPos);
        var ray = new Ray(CameraPos, direction);
        if (Gamemode.DebugMode)
        {
            Debug.DrawRay(CameraPos, direction);
        }
        var capsuleHits = Physics.SphereCastAll(ray, 2.0f, distance);

        var raycastHits = (capsuleHits.Select(element => element.collider.gameObject));
        var objectsToHide = raycastHits.Where(element => !HiddenObjects.Contains(element) && (element.GetComponent<Renderer>() != null));
        var objectsToShow = HiddenObjects.Where(element => !raycastHits.Contains(element) && (element.GetComponent<Renderer>() != null));

        foreach (var objectToHide in objectsToHide)
        {
            objectToHide.GetComponent<Renderer>().enabled = false;
            HiddenObjects.Add(objectToHide);
        }

        foreach (var objectToShow in objectsToShow.ToList())
        {
            objectToShow.GetComponent<Renderer>().enabled = true;
            HiddenObjects.Remove(objectToShow);
        }

        return;
    }

    private void MoveCamera()
    {
        var scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0)
        {
            var newCameraDistance = CameraDistance - (scrollWheelInput * 20);
            if (newCameraDistance > 100) newCameraDistance = 100;
            if (newCameraDistance < 40) newCameraDistance = 40;
            CameraDistance = newCameraDistance;
        }
        var pos = gameObject.transform.position;
        pos.y = pos.y + CameraDistance;
        pos.z = pos.z - (CameraDistance / 2);
        Camera.main.transform.position = pos;
    }

    private void UpdateTemperature()
    {
        if (IsInBuilding)
        {
            Temperature += 0.1f * Time.deltaTime;
        }

        if (Temperature >= 20 || Temperature <= 44)
        {
            Health = 0;
        }
    }

    private void Die()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float move = CrossPlatformInputManager.GetAxis("Vertical");
        float turn = CrossPlatformInputManager.GetAxis("Horizontal");
        bool run = Input.GetKey(KeyCode.LeftShift);
        Move(move, turn, run);
        HideObjects();
        //UpdateTemperature();
        //if (Health == 0)
        //{
        //    Die();
        //}
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
    }

    private void LeaveBuilding(GameObject building)
    {
        IsInBuilding = false;
        Building = null;
    }
}
