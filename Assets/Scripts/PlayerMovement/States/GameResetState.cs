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
    private float counter = 5f;

    public override void EnterState()
    {
        GameManager.Instance.GetComponent<GameStart>().GameplayCanvas.SetActive(false);
        PostDeathCanvas.SetActive(true);
        deathTime = Time.time;
        reviveCountDown = Time.time + counter;
        highScoreText.text = "TBD";
        fishCountText.text = $"x{GameManager.Instance.collectedFish.ToString()}";
        scoreText.text = GameManager.Instance.score.ToString();
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
            Invoke("InitializeGame", .1f);
        }
    }

    public void GoToMenu()
    {
        PostDeathCanvas.SetActive(false);
        _movement.ResetGame();
        Invoke("InitializeGame", .1f);
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
        PostDeathCanvas.SetActive(false);
    }
}
