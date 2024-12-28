using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : BaseState
{
    float jumpForce = 10.0f;
     public override void EnterState()
     {
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
         _movement.ApplyGravity();
         if(_movement.verticalVelocity < 0) _movement.ChangeState(GetComponent<FallingState>());
     }
}
