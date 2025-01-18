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
    
    public Transform playerTransform;

    //Score
    public int currentScore;
    public int highscore;
    private float distanceModifier = 1.5F;

    //Fish
    public int currentCollectedFish;
    public int totalCollectedFish;
    public float pointsPerFish = 1.5f;

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
        OnScoreChange?.Invoke(currentScore);
        int s = Convert.ToInt32(Math.Floor(playerTransform.position.z * distanceModifier));
        s += Convert.ToInt32(currentCollectedFish * pointsPerFish);
        
        if (s > currentScore)
        {
            currentScore = s;
            if (Time.time - lastScoreChange > scoreUpdateDelta)
            {
                lastScoreChange = Time.time;
                OnScoreChange?.Invoke(currentScore);
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
        return $"{currentScore:D7}";
    }

    public string FishToText()
    {
        return $"{currentCollectedFish:D4}";
    }
    

    public void ResetSession()
    {
        currentScore = 0;
        currentCollectedFish = 0;
        
        OnFishCollected?.Invoke(currentCollectedFish);
        OnScoreChange?.Invoke((int)currentScore);
    }
}
