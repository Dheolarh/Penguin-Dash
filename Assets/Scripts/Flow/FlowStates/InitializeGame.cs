using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitializeGame : FactoryState
{

    public override void EnterFlow()
    {
        flow.enabled = true;
        Debug.Log("Successfully entered Initial State");
        GameManager.Instance.penguin.transform.position = new Vector3(0, 0, 0);
        GameManager.Instance.worldManager.ResetWorld();
        Invoke("CallResetGame", 0.1f);
        Invoke("StartRunningState", 1f);
    }

    public override void UpdateFlow()
    {
        flow.enabled = true;
        // flow.penguin.transform.position = new Vector3(0, 0, 0);
        if (InputManager.Instance.tap && (GameManager.Instance.startGame.isPaused == true))
        {
            flow.ChangeFlow(GetComponent<GameStart>());
            Debug.Log("Game Start");
        }
    }

    public void CallResetGame()
    {
        GameManager.Instance.startGame.ResetGame();
    }

    private void StartRunningState()
    {
        GameManager.Instance.startGame.ChangeState(GameManager.Instance.startGame.GetComponent<RunningState>());
    }

    public override void ExitFlow()
    {
        Debug.Log("Exiting Initial State");
    }
}
