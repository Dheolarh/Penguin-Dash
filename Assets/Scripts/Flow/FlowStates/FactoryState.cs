using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryState : MonoBehaviour
{
    protected GameManager flow;
    protected PlayerMovement _movement;
    
    private void Awake()
    {
        _movement = FindObjectOfType<PlayerMovement>();
        if (_movement == null)
        {
            Debug.LogError("PlayerMovement not found");
        }
        flow = GetComponent<GameManager>();
    }
    public virtual void EnterFlow(){}
    public virtual void ExitFlow(){}
    public virtual void UpdateFlow(){}
    public virtual void StartFlow()
    {
        Debug.Log($"No action to do in {this.ToString()}");
    }
}
