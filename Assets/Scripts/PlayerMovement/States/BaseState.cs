using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected PlayerMovement _movement;
    public float airTime;
    public float elapsedAirTime;

    public virtual void EnterState()
    {
        Debug.Log($"Entered {this.ToString()}");
    }
    public virtual void ExitState(){}
    public virtual void UpdateState(){}

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }
    public virtual Vector3 StartState()
    {
        // Debug.Log($"No action to do in {this.ToString()}");
        return Vector3.zero;
    }
}
