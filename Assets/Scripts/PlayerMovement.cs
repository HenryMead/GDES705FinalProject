using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = 2.0f;
    
    private Vector3 playerVelocity;
    private Vector3 moveInput;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Update()
    {
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = transform.TransformDirection(move);
        controller.Move(move * playerSpeed);

        
        //look at mouse pos
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 5;
        }
        else playerSpeed = 2;
    }  
}
