using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResetState : BaseState
{
    public GameObject PostDeathCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI fishCountText;
    private float reviveCountDown;
    private float counter = 5f;

    public override void EnterState()
    {
        PostDeathCanvas.SetActive(true);
        reviveCountDown = Time.time + counter;
        //highScoreText.text = GameManager.Instance.GetComponent<InitializeGame>().highScoreText.text;
        //fishCountText.text = "Fish Count: ";
        Debug.Log($"isPaused in {this.ToString()} == {_movement.isPaused.ToString()}");
        Debug.Log("Entered Game Reset State");
    }
    
    public override void UpdateState()
    {
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
