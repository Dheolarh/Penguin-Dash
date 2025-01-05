using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameCameras
{
    MenuCam = 0,
    ShopCam = 1,
    PlayCam = 2,
    RespawnCam = 3,
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject
                    {
                        name = nameof(GameManager)
                    };
                    instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
    
    public FactoryState currentFlow;
    public PlayerMovement startGame;
    public List<GameObject> cameras;
    
    void Awake()
    {
        instance = this;
        currentFlow = GetComponent<InitializeGame>();
        currentFlow.EnterFlow();
    }
    
    void Start()
    {
        Debug.Log("Game Manager Started");
    }
    void Update()
    {
        currentFlow.UpdateFlow();
    }

    public void ChangeState(FactoryState newFlow)
    {
        currentFlow.ExitFlow();
        currentFlow = newFlow;
        currentFlow.EnterFlow();
    }
    
    public void ChangeCamera(GameCameras camera)
    {
        foreach (GameObject cam in cameras)
            cam.SetActive(false);
        
        cameras[(int)camera].SetActive(true);
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over");
        ReloadScene();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}
