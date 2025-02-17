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
        SaveManager.Instance.Save();
        GameManager.Instance.revived = false;
        GameManager.Instance.penguin.transform.position = new Vector3(0, 0, 0);
        GameManager.Instance.worldManager.ResetWorld();
        GameStats.Instance.ResetSession();
        Invoke("CallResetGame", 0.1f);
        Invoke("StartRunningState", 1f);
        highScoreText.text = $"HighScore: {SaveManager.Instance.saveData.HighScore:D7}";
        totalFishCountText.text = $"Total Fish: {SaveManager.Instance.saveData.Fish:D6}";
        MenuCanvas.SetActive(true);
        if (!AudioManager.Instance.gameSounds.loop) AudioManager.Instance.gameSounds.loop = true;
        AudioManager.Instance.gameSounds.volume = .5f;
        if (AudioManager.Instance.gameSounds.clip != AudioManager.Instance.menuSound)
        {
            AudioManager.Instance.gameSounds.Stop();
            AudioManager.Instance.gameSounds.clip = AudioManager.Instance.menuSound;
            AudioManager.Instance.gameSounds.Play();
        }
        GameStats.Instance.totalCollectedFish = 0;
    }

    public override void UpdateFlow()
    {
        if (!flow.isActiveAndEnabled)
        {
            flow.enabled = true;
        }
    }

    public override void FixedUpdateFlow()
    {
        base.FixedUpdateFlow();
    }
    public void OnPlayClick()
    {
        sfxAudioManager.Instance.sfxSound.PlayOneShot(sfxAudioManager.Instance.buttonClickSound);
        flow.ChangeFlow(GetComponent<GameStart>());
        GameStats.Instance.ResetSession();
    }
    
    public void OnShopClick()
    {
        sfxAudioManager.Instance.sfxSound.PlayOneShot(sfxAudioManager.Instance.buttonClickSound);
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
        MenuCanvas.SetActive(false);
    }
}
