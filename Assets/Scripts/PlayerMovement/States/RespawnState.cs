using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnState : BaseState
{
    [SerializeField] private float verticalHeight;

    [SerializeField] private float respawnTime = 1f;
    [SerializeField] private float respawnTimer;
    // Start is called before the first frame update
    public override void EnterState()
    {
        _movement.ResumeGame();
        GameManager.Instance.ChangeCamera(GameCameras.RespawnCam);
        respawnTimer = Time.time;
        _movement.jumpCount = 0;
        _movement.controller.enabled = false;
        _movement.transform.position = new Vector3(
            0,
            verticalHeight + 5f,
            _movement.playerTransform.position.z);
        _movement.controller.enabled = true;
        _movement.verticalVelocity = 0.0f;
        _movement.currentLane = 0;
        _movement.animator?.SetTrigger("Respawn");
    }
    
    public override Vector3 StartState()
    {
        _movement.ApplyGravity();
        Vector3 moveDirection = Vector3.zero;
        moveDirection.z = _movement.baseRunSpeed;
        moveDirection.y = _movement.verticalVelocity;
        moveDirection.x = _movement.SnapToLane();
          
        return moveDirection;
    }

    public override void UpdateState()
    {
        if (_movement.isGrounded && (Time.time - respawnTimer) > respawnTime) _movement.ChangeState(GetComponent<RunningState>());
        if (InputManager.Instance.swipeLeft) _movement.ChangeLane(-1);
        if (InputManager.Instance.swipeRight) _movement.ChangeLane(1);
    }
    
    public override void ExitState()
    {
        GameManager.Instance.ChangeCamera(GameCameras.PlayCam);
        Debug.Log("Exited Respawn State");
    }
}
