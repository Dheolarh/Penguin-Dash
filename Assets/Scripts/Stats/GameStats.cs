using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    private static GameStats instance;

    public static GameStats Instance { get{ return instance; } }

    private void Awake()
    {
        instance = this;
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
            if (Time.time - lastScoreChange > scoreUpdateDelta)
            {
                lastScoreChange = Time.time;
                OnScoreChange?.Invoke((int)currentScore);
            }
        }
    }

    public void CollectFish()
    {
        currentCollectedFish++;
        OnFishCollected?.Invoke(currentCollectedFish);
    }

    public string CurrentScoreToText()
    {
        return currentScore.ToString("0000000");
    }

    public string FishToText()
    {
        return currentCollectedFish.ToString("0000");
    }
    

    public void ResetSession()
    {
        currentScore = 0;
        currentCollectedFish = 0;
        
        OnFishCollected?.Invoke(currentCollectedFish);
        OnScoreChange?.Invoke((int)currentScore);
    }
}
