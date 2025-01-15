using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats instance;

    public static GameStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameStats>();
                if (instance == null)
                {
                    GameObject go = new GameObject
                    {
                        name = nameof(GameStats)
                    };
                    instance = go.AddComponent<GameStats>();
                    DontDestroyOnLoad(go);
                }
            }

            return instance;
        }
    }
    
    //Score
    public int currentScore;
    public int highscore;
    
    //Fish
    public int currentCollectedFish;
    public int totalCollectedFish;

    public Action<int> OnScoreChange;
    public Action<int> OnfishCollected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       currentScore = Convert.ToInt32(Math.Floor((GameManager.Instance.startGame.playerTransform.position.z)));
        
    }
}
