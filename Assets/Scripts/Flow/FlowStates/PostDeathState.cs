using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDeathState : FactoryState
{
    public override void EnterFlow()
    {
        Debug.Log("Post Death Menu");
    }
    
    public override void UpdateFlow()
    {
        if (InputManager.Instance.tap)
        {
            Debug.Log("Respawn");
            RespawnState respawn = _movement.GetComponent<RespawnState>();
            if (respawn !)
            {
                _movement.ChangeState(respawn);
            }
            else
            {
                Debug.LogError("RespawnState not found");
            }
        }
    }
}
