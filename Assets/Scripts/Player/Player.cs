using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;

public class Player : MonoBehaviour
{
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
    private List<Collider> HiddenObjects = new List<Collider>();

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
        var direction = CameraPos - PlayerPos;
        var CapsuleHits = Physics.CapsuleCastAll(CameraPos, PlayerPos, 2, transform.forward);

        foreach (var hit in CapsuleHits)
        {
            var collider = hit.collider;
            var renderer = collider.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color color = renderer.material.color;
                color.a -= 0.5f;
                renderer.material.color = color;
                HiddenObjects.Add(collider);
            }
        }
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
    }

    private void LeaveBuilding(GameObject building)
    {
        IsInBuilding = false;
        Building = null;
    }
}
