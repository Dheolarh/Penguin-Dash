using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStart : FactoryState
{
    public GameObject GameplayCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI fishCountText;
    public override void EnterFlow()
    {
        GameManager.Instance.startGame.ResumeGame();
        GameManager.Instance.ChangeCamera(GameCameras.PlayCam);
        Debug.Log("Game Start");
        GameplayCanvas.SetActive(true);
    }
    
    public override void UpdateFlow()
    {
        GameManager.Instance.worldManager.ScanPosition();
        scoreText.text = "10000";
        fishCountText.text = "100";
    }
    
    public override void ExitFlow()
    {
        Debug.Log("Exiting Game Start");
        GameplayCanvas.SetActive(false);
    }
}
    