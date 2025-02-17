using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get {return instance;} }
    private static AudioManager instance;


    public AudioSource gameSounds;

    public AudioClip menuSound;
    public AudioClip ingameSound;

    
    //Shop Sounds
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        gameSounds = GetComponent<AudioSource>();
        gameSounds.loop = true;
    }

    public void IncreaseVolume()
    {
        gameSounds.volume = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
