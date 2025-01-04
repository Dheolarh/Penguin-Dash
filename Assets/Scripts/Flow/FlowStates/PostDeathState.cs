using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDeathState : FactoryState
{
    public override void EnterFlow()
    {
    }
    
    public override void UpdateFlow()
    {
        if (InputManager.Instance.tap)
        {
            GameManager.Instance.startGame.Respawn();
        }
    }


}
