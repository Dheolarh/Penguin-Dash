using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitializeGame : FactoryState
{

    public override void EnterFlow()
    {
        Debug.Log("Successfully entered Initial State");
        GameManager.Instance.ChangeCamera(GameCameras.MenuCam);
    }
    // Start is called before the first frame update
    public override void UpdateFlow()
    {
        if (InputManager.Instance.tap)
        {
            flow.ChangeState(GetComponent<GameStart>());
            Debug.Log("Game Start");
        }
    }

    public override void ExitFlow()
    {
        Debug.Log("Exiting Initial State");
    }
}
