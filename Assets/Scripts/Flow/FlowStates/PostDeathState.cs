using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDeathState : FactoryState
{
    public override void EnterFlow()
    {
        Debug.Log("Entered Post Death State");
    }
    
    public override void UpdateFlow()
    {
        if (InputManager.Instance.tap) GameManager.Instance.startGame.Respawn();
        if (InputManager.Instance.swipeDown)
        {
            Debug.Log("Swiped Down");
            flow.ChangeState(GetComponent<InitializeGame>());
            GameManager.Instance.startGame.ResetGame();
        }
    }
}
