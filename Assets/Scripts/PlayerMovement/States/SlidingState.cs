using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingState : BaseState   
{
   [SerializeField] private float initialHeight;
   [SerializeField] private Vector3 initialCenter;
   
   [SerializeField] private float slideStartTime;
   [SerializeField] private float slideDuration;

   public override void EnterState()
   {
      _movement.jumpCount = 0;
      Debug.Log(Time.time);
      _movement.animator.SetTrigger("Slide");
      slideStartTime = Time.time;
      Debug.Log($"Entered {this.ToString()}");
      
      initialHeight = _movement.controller.height;
      initialCenter = _movement.controller.center;
      
      _movement.controller.center = new Vector3(0, 0.2f, 0);
      _movement.controller.height = 0.2f;
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
      if (Time.time - slideStartTime > slideDuration) _movement.ChangeState(GetComponent<RunningState>());
      if (InputManager.Instance.swipeLeft) _movement.ChangeLane(-1);
      if (InputManager.Instance.swipeRight) _movement.ChangeLane(1);
      if (!_movement.isGrounded) _movement.ChangeState(GetComponent<FallingState>());
      if(InputManager.Instance.swipeUp) _movement.ChangeState(GetComponent<JumpingState>());
   }

   public override void ExitState()
   {
      Debug.Log(Time.time);
      _movement.controller.height = initialHeight;
      _movement.controller.center = initialCenter;
      _movement.animator?.SetTrigger("Running");
   }
}
 