using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResetState : BaseState
{
    public override void EnterState()
    {
        Debug.Log($"isPaused in {this.ToString()} == {_movement.isPaused.ToString()}");
        Debug.Log("Entered Game Reset State");
    }
    
    public override void UpdateState()
    {
        if (InputManager.Instance.tap)
        {
            _movement.PauseGame();
            Debug.Log("Tapped");
            _movement.Respawn();
        }
        else if (InputManager.Instance.swipeDown)
        {
            Debug.Log("Swiped Down");
            _movement.ResetGame();
            Invoke("InitializeGame", 0.3f);
        }
    }

    public void InitializeGame()
    {
        GameManager.Instance.ChangeFlow(GameManager.Instance.GetComponent<InitializeGame>());
    }
    
    public override void ExitState()
    {
        
    }
}
