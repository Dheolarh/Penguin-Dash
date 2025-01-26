using UnityEngine;
using TMPro;
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
        fishCountText.text = GameStats.Instance.FishToText();
    }

    private void Score(int currentScore)
    {
        scoreText.text = GameStats.Instance.CurrentScoreToText();
    }

    public override void UpdateFlow()
    {
        GameManager.Instance.worldManager.ScanPosition();
    }
    
    private void highScoreAlert(GameObject highScoreBoard)
    {
        Debug.Log("High Score Alert");
        highScoreBoard.SetActive(true);
        Invoke("DisableNotifier", 5f);
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
    }
}
    