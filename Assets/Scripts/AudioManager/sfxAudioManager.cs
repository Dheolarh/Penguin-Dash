using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static sfxAudioManager Instance { get {return instance;} }
    private static sfxAudioManager instance;


    public AudioSource sfxSound;

    //Ingame
    public AudioClip crashSound;
    public AudioClip pickupSound;
    public AudioClip reviveSound;
    public AudioClip deathSound;
    public AudioClip highScoreSound;
    
    //Shop Sounds
    public AudioClip buttonClickSound;
    public AudioClip noMoneySound;
    public AudioClip purchaseSound;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        sfxSound = GetComponent<AudioSource>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
