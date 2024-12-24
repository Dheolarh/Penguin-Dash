using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected PlayerMovement _movement;
    public virtual void EnterState(){}
    public virtual void ExitState(){}
    public virtual void UpdateState(){}

    public virtual Vector3 StartState()
    {
        Debug.Log($"State not started in {this.ToString()}");
        return Vector3.zero;
    }
}
