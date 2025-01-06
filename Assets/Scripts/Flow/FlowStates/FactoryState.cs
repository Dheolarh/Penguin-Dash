using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryState : MonoBehaviour
{
    protected GameManager flow;
    
    private void Awake()
    {
        flow = GetComponent<GameManager>();
    }

    public virtual void EnterFlow()
    {
        Debug.Log($"Entered {this.ToString()}");

    }
    public virtual void ExitFlow(){}
    public virtual void UpdateFlow(){}
    public virtual void StartFlow()
    {
        Debug.Log($"No action to do in {this.ToString()}");
    }
}
