using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;      
using UnityEngine.UI;

public class InitializeGame : FactoryState
{
    public GameObject MenuCanvas;
    [SerializeField] public TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI totalFishCountText;

    public override void EnterFlow()
    {
        // flow.enabled = true;
        GameManager.Instance.penguin.transform.position = new Vector3(0, 0, 0);
        GameManager.Instance.worldManager.ResetWorld();
        Invoke("CallResetGame", 0.1f);
        Invoke("StartRunningState", 1f);
        highScoreText.text = $"HighScore: {SaveManager.Instance.saveData.HighScore:D7}";
        totalFishCountText.text = $"Total Fish: {SaveManager.Instance.saveData.Fish:D6}";
        MenuCanvas.SetActive(true);
    }

    public override void UpdateFlow()
    {
        flow.enabled = true;
    }

    public override void FixedUpdateFlow()
    {
        base.FixedUpdateFlow();
    }
    public void OnPlayClick()
    {
        flow.ChangeFlow(GetComponent<GameStart>());
        GameStats.Instance.ResetSession();
    }
    
    public void OnShopClick()
    {
        flow.ChangeFlow(GetComponent<ShopState>());
    }
        

    public void CallResetGame()
    {
        GameManager.Instance.startGame.ResetGame();
    }

    private void StartRunningState()
    {
        GameManager.Instance.startGame.ChangeState(GameManager.Instance.startGame.GetComponent<RunningState>());
    }

    public override void ExitFlow()
    {
        Debug.Log("Exiting Initial State");
        MenuCanvas.SetActive(false);
    }
}
