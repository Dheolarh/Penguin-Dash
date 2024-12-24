using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public BaseState currentState;
    
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
        currentState = GetComponent<RunningState>();
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = controller.isGrounded; //Check if the player is grounded

        moveDirections = currentState.StartState(); //Get the movement direction from the current state (Start the current state which is running state)
        
        currentState.UpdateState(); //Update the current state (changes in current state e.g. changing lanes with swipe)
        
        controller.Move(moveDirections * Time.deltaTime); //Move the player
    }
    
    public float SnapToLane()
    {
        float xPosition = 0.0f;
        if (transform.position.x != currentLane * distanceBetweenLanes)
        {
            float deltaToLane = (currentLane * distanceBetweenLanes) - transform.position.x;
            xPosition = (deltaToLane > 0) ? 1 : -1;
            xPosition *= baseSidewaySpeed;
            
            float moveDistance = xPosition * Time.deltaTime;
            if (Mathf.Abs(moveDistance) > Mathf.Abs(deltaToLane))
            {
                xPosition = deltaToLane * (1/Time.deltaTime);
            }
        }
        else
        {
            xPosition = 0.0f;
        }
        return xPosition;
    }   
    
    public void ChangeLane(int direction)
    {
        currentLane += Mathf.Clamp(direction, -1, 1);
    }
    public void ChangeState(BaseState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    public void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        if (verticalVelocity < -maxVelocity)
        {
            verticalVelocity = -maxVelocity;
        }
    }
}
