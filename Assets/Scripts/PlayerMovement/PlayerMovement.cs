using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
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
}
