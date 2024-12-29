using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    void Awake()
    {
        instance = this;
        currentFlow = GetComponent<InitializeGame>();
        currentFlow.EnterFlow();
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
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
