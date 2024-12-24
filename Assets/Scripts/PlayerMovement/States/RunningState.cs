using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : BaseState
{
    public override void EnterState()
    {
        _movement = GetComponent<PlayerMovement>();
        Debug.Log("Entered Running State");
    }

    public override void ExitState()
    {
        Debug.Log("Exited Running State");
    }



    public override Vector3 StartState()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.z = _movement.baseRunSpeed;
        moveDirection.y = -1.0f;
        moveDirection.x = 0;
        return moveDirection;
    }

    public override void UpdateState()
    {
        if (InputManager.Instance.swipeLeft)
        {
           _movement.ChangeLane(-1);
        }
        if (InputManager.Instance.swipeRight)
        {
            _movement.ChangeLane(1);
        }

        if (InputManager.Instance.swipeUp && _movement.isGrounded)
        {
           //_movement.ChangeState(GetComponent<JumpingState>());
        }

        if (InputManager.Instance.swipeDown && _movement.isGrounded)
        {
            // _movement.ChangeState(GetComponent<SlidingState>());
        }
    }

}
