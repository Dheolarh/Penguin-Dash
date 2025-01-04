using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitializeGame : FactoryState
{

    public override void EnterFlow()
    {
        GameManager.Instance.ChangeCamera(GameCameras.MenuCam);
    }
    // Start is called before the first frame update
    public override void UpdateFlow()
    {
        if (InputManager.Instance.tap && GameManager.Instance.startGame.isPaused)
        {
            flow.ChangeState(GetComponent<GameStart>());
            Debug.Log("Game Start");
        }
    }
}
