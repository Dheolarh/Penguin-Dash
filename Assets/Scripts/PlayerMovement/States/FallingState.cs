using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : BaseState
{
    // Start is called before the first frame update
    public override void EnterState()
    {
        Debug.Log("Entered Falling State");
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
        if (_movement.isGrounded)
        {
            _movement.ChangeState(GetComponent<RunningState>());
        }
    }
    
}
