using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator { get; set; }
    public BaseState currentState;
    public bool isPaused;
    public Transform playerTransform;

    public bool deathDebug = false;
    
    [HideInInspector] public Vector3 moveDirections;
    [HideInInspector] public float verticalVelocity;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public int currentLane;
    
    public float distanceBetweenLanes = 3.0f;
    public float gravity = 11.0f;
    public float maxVelocity = 20.0f;
    public float baseRunSpeed = 10.0f;
    public float baseSidewaySpeed = 10.0f;
    public int jumpCount;
    public int slideCount;
    
    void Start()
    {
        Debug.Log("Player Movement Started");
        isPaused = true;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        currentState = GetComponent<RunningState>();
        currentState.EnterState();
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(currentState.ToString());
        // Debug.Log(GameManager.Instance.currentFlow.ToString());
        if (!isPaused) Movement();
       
    }

    private void FixedUpdate()
    {
        
    }

    private void Movement()
    {
        isGrounded = controller.isGrounded; //Check if the player is grounded

        moveDirections = currentState.StartState(); //Get the movement direction from the current state (Start the current state which is running state)
        
        currentState.UpdateState(); //Update the current state (changes in current state e.g. changing lanes with swipe)
        
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirections.z));
        
        controller.Move(moveDirections * Time.deltaTime); //Move the player
        if (!isGrounded) ApplyGravity();
        if (currentState == GetComponent<SlidingState>())
        {
            controller.height = 0.2f;
            controller.center = new Vector3(0, 0.2f, 0);
        }
        else
        {
            controller.height = 1;
            controller.center = new Vector3(0, 0.5f, 0);
        }
    }
    
    public float SnapToLane()
    {
        float xPosition = 0.0f;
        if (transform.position.x != (currentLane * distanceBetweenLanes))
        {
            float deltaToLane = (currentLane * distanceBetweenLanes) - transform.position.x;
            xPosition = (deltaToLane > 0) ? 1 : -1;
            xPosition *= baseSidewaySpeed;
            
            float moveDistance = xPosition * Time.deltaTime;
            if (Mathf.Abs(moveDistance) > Mathf.Abs(deltaToLane)) xPosition = deltaToLane * (1/Time.deltaTime);
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
    
    public void Respawn()
    {
        ChangeState(GetComponent<RespawnState>());
    }
    
    
    public void ResetGame()
    {
        GameManager.Instance.ChangeCamera(GameCameras.MenuCam);
        animator?.SetTrigger("Idle");
        PauseGame();
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        deathDebug = true;
        string hitLayerName = LayerMask.LayerToName(hit.gameObject.layer);
        if (hitLayerName == "Death" && deathDebug == true)
        {
            Debug.Log($"Death Bug in {this.ToString()} == {deathDebug.ToString()}");
            ChangeState(GetComponent<DeathState>());
        }
    }
    
    private void OnDisable()
    {
        enabled = true;
    }
}
