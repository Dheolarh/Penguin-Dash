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
    
    public int currentScore;
    public int highscore;
    public int currentCollectedFish;
    public int totalCollectedFish;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
