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
        GameStats.Instance.OnFishCollected += CollectedFish;
        GameStats.Instance.OnScoreChange += Score;
        GameplayCanvas.SetActive(true);
    }

    private void CollectedFish(int collectedFish)
    {
        fishCountText.text = GameStats.Instance.CurrentScoreToText();
    }

    private void Score(int currentScore)
    {
        scoreText.text = GameStats.Instance.FishToText();
    }

    public override void UpdateFlow()
    {
        GameManager.Instance.worldManager.ScanPosition();
    }

    public override void ExitFlow()
    {
        Debug.Log("Exiting Game Start");
        GameplayCanvas.SetActive(false);
        GameStats.Instance.OnFishCollected -= CollectedFish;
        GameStats.Instance.OnScoreChange -= Score;
    }
}
    