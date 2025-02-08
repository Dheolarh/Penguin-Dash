using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class GameResetState : BaseState, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public GameObject PostDeathCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI fishCountText;
    [SerializeField] private Image countdownCircle;
    private float reviveCountDown;
    private float deathTime;
    private float counter = 3f;

    private void Start()
    {
    }

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
        if(!GameManager.Instance.revived) countdownCircle.gameObject.SetActive(true);
        deathTime = Time.time;
        reviveCountDown = Time.time + counter;
        highScoreText.text = $"Highscore: {SaveManager.Instance.saveData.HighScore:D7}";
        fishCountText.text = GameStats.Instance.FishToText();
        scoreText.text = GameStats.Instance.CurrentScoreToText();
    }

    public override void UpdateState()
    {
        if (!GameManager.Instance.revived)
        {
            float circleCounter = (Time.time - deathTime) / counter;
            countdownCircle.color = Color.Lerp(Color.green, Color.red, circleCounter);
            countdownCircle.fillAmount = 1 - circleCounter;
            if (Time.time >= reviveCountDown && countdownCircle.gameObject.activeSelf)
            {
                PostDeathCanvas.SetActive(false);
                _movement.ResetGame();
                SaveManager.Instance.saveData.Fish += GameStats.Instance.totalCollectedFish;
                Invoke("InitializeGame", .1f);
            }
        }
    }
    
    public void StopCountdown()
    {
        countdownCircle.gameObject.SetActive(false);
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
        GameManager.Instance.revived = true;
    }

    public void TryRevive()
    {
        Debug.Log("Trying to revive.... Showing ad");
        Admanager.Instance.ShowRewardedAd();
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

    public void OnInitializationComplete()
    {
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
       Debug.Log(message);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("0N UNITY ADS SHOW COMPLETE");
        if (placementId == Admanager.Instance.rewardedAdID)
        {
            switch (showCompletionState)
            {
                case UnityAdsShowCompletionState.SKIPPED:
                    Debug.Log("Ad was skipped");
                    Revive();
                    break;
                case UnityAdsShowCompletionState.UNKNOWN:
                    Debug.Log("Ad status is unknown");
                    GoToMenu();
                    break;
                case UnityAdsShowCompletionState.COMPLETED:
                    Debug.Log("Ad was completed");
                    Revive();
                    break;
            }
        };
    }
}