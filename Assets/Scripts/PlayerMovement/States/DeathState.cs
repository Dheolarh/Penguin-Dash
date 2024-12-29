using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    public override void EnterState()
    {
       _movement.animator?.SetTrigger("Death");
       _movement.GameOver();
       Invoke("ReloadScene", 2.0f);
    }
    
    void ReloadScene()
    {
        GameManager.Instance.ReloadScene();
    }
}
