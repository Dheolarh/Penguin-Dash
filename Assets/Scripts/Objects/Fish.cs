using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class Fish : MonoBehaviour
{

    private Animator anims;
    
    void Start()
    {
        anims = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") PickUpFish();
    }

    private void PickUpFish()
    {
        sfxAudioManager.Instance.sfxSound.PlayOneShot(sfxAudioManager.Instance.pickupSound);
        anims?.SetTrigger("Pickup");
        GameStats.Instance.CollectFish();
    }

    
    [UsedImplicitly]
    public void OnShowChunk()
    {
        anims?.SetTrigger("Idle");
    }
}
