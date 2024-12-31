using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitializeGame : FactoryState
{
    // Start is called before the first frame update
    public override void UpdateFlow()
    {
        if (InputManager.Instance.tap && GameManager.Instance.startGame.isPaused)
        {
            flow.ChangeState(GetComponent<GameStart>());
            Debug.Log("Game Start");
        }
    }
    
    public void RetryGame()
    {
        flow.ChangeState(GetComponent<GameStart>());
    }
}
