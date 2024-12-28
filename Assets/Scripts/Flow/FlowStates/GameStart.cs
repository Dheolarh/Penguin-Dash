using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : FactoryState
{
    public override void EnterFlow()
    {
        GameManager.Instance.startGame.ResumeGame();
        Debug.Log("Game Start");
    }
}
    