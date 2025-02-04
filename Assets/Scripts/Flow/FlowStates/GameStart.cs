using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameStart : FactoryState
{
    public GameObject GameplayCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI fishCountText;
    [SerializeField] private TextMeshProUGUI countdownTimer;
    private int counter = 3;
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
        fishCountText.text = GameStats.Instance.FishToText();
    }

    private void Score(int currentScore)
    {
        scoreText.text = GameStats.Instance.CurrentScoreToText();
    }

    public override void UpdateFlow()
    {
        GameManager.Instance.worldManager.ScanPosition();
        if (GameManager.Instance.TutorialCanvas.activeSelf == true)
        {
            if (InputManager.Instance.tap)
            {
                GameManager.Instance.tutorialCanvas.color = new Color(1f, 1f, 1f, 0 / 255);
                StartCoroutine(ResumePlayCountdown());
            }
        }
    }

    IEnumerator ResumePlayCountdown()
    {
        GameManager.Instance.tutorialStartTime = Time.time;
        int timeLeft = counter;
        while (timeLeft > 0)
        {
            timeLeft = counter - (int)(Time.time - GameManager.Instance.tutorialStartTime);
            countdownTimer.text = timeLeft.ToString();
            yield return null;
        }
        GameManager.Instance.TutorialCanvas.SetActive(false);
        GameManager.Instance.startGame.ResumeGame();
        SaveManager.Instance.saveData.FirstTime = false;
    }

    public override void FixedUpdateFlow()
    {
        base.FixedUpdateFlow();
    }

    public override void ExitFlow()
    {
        Debug.Log("Exiting Game Start");
        GameplayCanvas.SetActive(false);
        GameStats.Instance.OnFishCollected -= CollectedFish;
        GameStats.Instance.OnScoreChange -= Score;
        SaveManager.Instance.saveData.FirstHighScore = true;
    }
}
    