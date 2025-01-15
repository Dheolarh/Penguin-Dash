using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameStart : FactoryState
{
    public GameObject GameplayCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI fishCountText;
    public override void EnterFlow()
    {
        if (GameManager.Instance.startGame.isPaused == true)
        {
            GameManager.Instance.startGame.ResumeGame();
        }
        GameManager.Instance.ChangeCamera(GameCameras.PlayCam);
        Debug.Log("Game Start");
        GameplayCanvas.SetActive(true);
    }
    
    public override void UpdateFlow()
    {
        int fishes = GameStats.Instance.currentCollectedFish; 
        GameManager.Instance.worldManager.ScanPosition();
        scoreText.text = $"{GameStats.Instance.currentScore:D8}";
        fishCountText.text = $"{fishes:D5}";
    }
    
    public override void ExitFlow()
    {
        Debug.Log("Exiting Game Start");
        GameplayCanvas.SetActive(false);
    }
}
    