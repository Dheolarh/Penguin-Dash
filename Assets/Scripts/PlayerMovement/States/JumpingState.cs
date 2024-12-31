using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : BaseState
{
    float jumpForce = 12.0f;
     public override void EnterState()
     {
         airTime = Time.time;
         _movement.animator.SetTrigger("Jump");
         _movement.verticalVelocity = jumpForce;
         Debug.Log($"Entered {this.ToString()}");
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
         elapsedAirTime = Time.time;
         if((elapsedAirTime - airTime) <= 1.5f && _movement.jumpCount < 1 && InputManager.Instance.swipeUp )
         {
             _movement.jumpCount++;
             _movement.ChangeState(GetComponent<JumpingState>());
         }
         _movement.ApplyGravity();
         if(_movement.verticalVelocity < 0) _movement.ChangeState(GetComponent<FallingState>());
     }

     public override void ExitState()
     {
         Debug.Log(_movement.jumpCount);
     }
}
