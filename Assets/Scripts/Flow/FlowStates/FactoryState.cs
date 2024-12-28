using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryState : MonoBehaviour
{
    protected GameManager system;
    
    private void Awake()
    {
        system = GetComponent<GameManager>();
    }
    public virtual void EnterState(){}
    public virtual void ExitState(){}
    public virtual void UpdateState(){}
    public virtual Vector3 StartState()
    {
        Debug.Log($"No action to do in {this.ToString()}");
        return Vector3.zero;
    }
}
