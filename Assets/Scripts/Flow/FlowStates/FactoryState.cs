using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryState : MonoBehaviour
{
    protected GameManager flow;
    
    protected virtual void Awake()
    {
        flow = GetComponent<GameManager>();
    }

    public virtual void EnterFlow()
    {
    }
    public virtual void ExitFlow(){}
    public virtual void UpdateFlow(){}
    public virtual void FixedUpdateFlow(){}
    public virtual void StartFlow()
    {
    }
}
