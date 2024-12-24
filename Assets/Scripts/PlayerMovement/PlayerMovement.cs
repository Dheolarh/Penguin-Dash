using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [HideInInspector] public Vector3 moveDirections;
    [HideInInspector] public float verticalVelocity;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public int currentLane;
    
    public float distanceBetweenLanes = 3.0f;
    public float gravity = 15.0f;
    public float maxVelocity = 20.0f;
    public float baseRunSpeed = 5.0f;
    public float baseSidewaySpeed = 10.0f;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = controller.isGrounded; //Check if the player is grounded
        
        controller.Move(moveDirections * Time.deltaTime); //Move the player
    }
}
