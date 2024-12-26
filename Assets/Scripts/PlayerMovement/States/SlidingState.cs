using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingState : BaseState   
{
   public float slideDuration = 1.0f;
   
   // Collider minimization logic
   public Vector3 initalCenter;
   public float initialSize;
   public float slideStart;

   public override void EnterState()
   {
      _movement.animator.SetTrigger("Slide");
      slideStart = Time.time;
      initalCenter = _movement.controller.center;
      initialSize = _movement.controller.height;
      _movement.controller.height = 0.2f;
      _movement.controller.center = new Vector3(0, 0.2f, 0);
   }

   public override void ExitState()
   {
      _movement.animator?.SetTrigger("Running");
      _movement.controller.height = initialSize;
      _movement.controller.center = initalCenter;
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
      if (!_movement.isGrounded)
      {
         _movement.ChangeState(GetComponent<FallingState>());
      }
      if(InputManager.Instance.swipeUp)
      {
         _movement.ChangeState(GetComponent<JumpingState>());
      }

      if (Time.time - slideStart > slideDuration)
      {
         _movement.ChangeState(GetComponent<RunningState>());
      }
   }
   
   public override Vector3 StartState()
   {
      Vector3 moveDirection = Vector3.zero;
      moveDirection.z = _movement.baseRunSpeed;
      moveDirection.y = _movement.verticalVelocity;
      moveDirection.x = _movement.SnapToLane();
      return moveDirection;
   }
}
 