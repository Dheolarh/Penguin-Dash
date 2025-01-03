using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : FactoryState
{
    public override void EnterFlow()
    {
        GameManager.Instance.startGame.ResumeGame();
        GameManager.Instance.ChangeCamera(GameCameras.GameState);
        Debug.Log("Game Start");
    }
}
    