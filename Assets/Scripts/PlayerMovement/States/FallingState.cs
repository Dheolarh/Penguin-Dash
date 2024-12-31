using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : BaseState
{
    
    // Start is called before the first frame update
    public override void EnterState()
    {
        _movement.animator.SetTrigger("Fall");
        Debug.Log($"Entered {this.ToString()}");
    }
    
    public override Vector3 StartState()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.z = _movement.baseRunSpeed;
        moveDirection.y = _movement.verticalVelocity;
        moveDirection.x = _movement.SnapToLane();
        return moveDirection;
    }
    
    public override void UpdateState()
    {
        if((elapsedAirTime - airTime) <= 1.5f && _movement.jumpCount < 1 && InputManager.Instance.swipeUp )
        {
            _movement.jumpCount++;
            _movement.ChangeState(GetComponent<JumpingState>());
        }
        if (InputManager.Instance.swipeLeft) _movement.ChangeLane(-1);
        if (InputManager.Instance.swipeRight) _movement.ChangeLane(1);
        if (_movement.isGrounded) _movement.ChangeState(GetComponent<RunningState>());
    }
    
}
