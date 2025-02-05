using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : BaseState
{
    public bool timeCheck;
    public override void EnterState()
    {
        _movement.jumpCount = 0;
        
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
        if (SaveManager.Instance.saveData.FirstTime == true)
        {
            Invoke("StartTutorial", 0.5f);
        }
        else
        {
            if (InputManager.Instance.swipeLeft) _movement.ChangeLane(-1);
            if (InputManager.Instance.swipeRight) _movement.ChangeLane(1);
            if (InputManager.Instance.swipeUp && _movement.isGrounded) _movement.ChangeState(GetComponent<JumpingState>());
            if (InputManager.Instance.swipeDown) _movement.ChangeState(GetComponent<SlidingState>());
            if (!_movement.isGrounded) _movement.ChangeState(GetComponent<FallingState>());
        }
    }

    void StartTutorial()
    {
        if(!timeCheck)
        {
            GameManager.Instance.PauseTime();
            timeCheck = true;
        }
        GameManager.Instance.TutorialCanvas.SetActive(true);
    }
    public override void ExitState()
    { 
    }

}
