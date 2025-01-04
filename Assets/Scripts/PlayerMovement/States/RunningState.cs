using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : BaseState
{
    public override void EnterState()
    {
        _movement.jumpCount = 0;
        Debug.Log($"Entered {this.ToString()}");
        _movement.animator?.SetTrigger("Running");
        _movement.verticalVelocity = 0;
    }

    public override Vector3 StartState()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.z = _movement.baseRunSpeed;
        moveDirection.y = -1.0f;
        moveDirection.x = _movement.SnapToLane();
        return moveDirection;
    }

    public override void UpdateState()
    {
        if (InputManager.Instance.swipeLeft) _movement.ChangeLane(-1);
        if (InputManager.Instance.swipeRight) _movement.ChangeLane(1);
        if (InputManager.Instance.swipeUp && _movement.isGrounded) _movement.ChangeState(GetComponent<JumpingState>());
        if (InputManager.Instance.swipeDown) _movement.ChangeState(GetComponent<SlidingState>());
        if (!_movement.isGrounded) _movement.ChangeState(GetComponent<FallingState>());
    }
    public override void ExitState()
    { 
        Debug.Log("Exited Running State");
    }

}
