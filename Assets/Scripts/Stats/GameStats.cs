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
    public float currentScore;
    public float highscore;
    public float distanceModifier;

    //Fish
    public int currentCollectedFish;
    public int totalCollectedFish;
    public float pointsPerFish;

    //Internal Cooldown
    private float lastScoreChange;
    private float scoreUpdateDelta = 0.2f;
    
    // Events
    public Action<int> OnScoreChange;
    public Action<int> OnFishCollected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float s = GameManager.Instance.startGame.playerTransform.position.z * distanceModifier;
        s += currentCollectedFish * pointsPerFish;

        if (s > currentScore)
        {
            currentScore = s;
            OnScoreChange?.Invoke((int)currentScore);
        }
    }

    public void CollectFish()
    {
        currentCollectedFish++;
        OnFishCollected?.Invoke(currentCollectedFish);
    }
}
