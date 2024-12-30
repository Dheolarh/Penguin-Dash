using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingState : BaseState   
{
   public float slideDuration = 3.0f;
   public float slideStart;

   public override void EnterState()
   {
      _movement.animator.SetTrigger("Slide");
      slideStart = Time.time;
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
      if (Time.time - slideStart > slideDuration) _movement.ChangeState(GetComponent<RunningState>());
      if (InputManager.Instance.swipeLeft) _movement.ChangeLane(-1);
      if (InputManager.Instance.swipeRight) _movement.ChangeLane(1);
      if (!_movement.isGrounded) _movement.ChangeState(GetComponent<FallingState>());
      if(InputManager.Instance.swipeUp) _movement.ChangeState(GetComponent<JumpingState>());
   }

   public override void ExitState()
   {
      _movement.animator?.SetTrigger("Running");
   }


   

}
 