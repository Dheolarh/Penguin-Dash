using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameResetState : BaseState
{
    public GameObject PostDeathCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI fishCountText;
    [SerializeField] private Image countdownCircle;
    private float reviveCountDown;
    private float deathTime;
    private float counter = 3f;

    public override void EnterState()
    {
        GameManager.Instance.GetComponent<GameStart>().GameplayCanvas.SetActive(false);
        GameStats.Instance.totalCollectedFish += GameStats.Instance.currentCollectedFish;
        if (GameStats.Instance.currentScore > SaveManager.Instance.saveData.HighScore)
        {
            SaveManager.Instance.saveData.HighScore = GameStats.Instance.currentScore;
            highScoreText.color = Color.green;
            SaveManager.Instance.Save();
        }
        else
        {
            highScoreText.color = Color.white;
        }
        PostDeathCanvas.SetActive(true);
        deathTime = Time.time;
        reviveCountDown = Time.time + counter;
        highScoreText.text = $"Highscore: {SaveManager.Instance.saveData.HighScore:D7}";
        fishCountText.text = GameStats.Instance.FishToText();
        scoreText.text = GameStats.Instance.CurrentScoreToText();
        Debug.Log("Entered Game Reset State");
    }
    
    public override void UpdateState()
    {
        float circleCounter = (Time.time - deathTime) / counter;
        countdownCircle.color = Color.Lerp(Color.green, Color.red, circleCounter);
        countdownCircle.fillAmount = 1 - circleCounter;
        if (Time.time >= reviveCountDown)
        {
            PostDeathCanvas.SetActive(false);
            _movement.ResetGame();
            SaveManager.Instance.saveData.Fish += GameStats.Instance.totalCollectedFish;
            Invoke("InitializeGame", .1f);
        }
    }

    public void GoToMenu()
    {
        PostDeathCanvas.SetActive(false);
        _movement.ResetGame();
        Invoke("InitializeGame", .1f);
        
        if (GameStats.Instance.currentScore > SaveManager.Instance.saveData.HighScore)
            SaveManager.Instance.saveData.HighScore = GameStats.Instance.currentScore;
        
        SaveManager.Instance.saveData.Fish += GameStats.Instance.totalCollectedFish;
        
        SaveManager.Instance.Save();
    }

    public void Revive()
    {
        PostDeathCanvas.SetActive(false);
        _movement.PauseGame();
        _movement.Respawn();
    }

    public void InitializeGame()
    {
        GameManager.Instance.ChangeFlow(GameManager.Instance.GetComponent<InitializeGame>());
    }
    
    public override void ExitState()
    {
        SaveManager.Instance.Save();
        PostDeathCanvas.SetActive(false);
    }
}
