using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Animator anims;

    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) PickUpFish();
    }

    private void PickUpFish()
    {
        anims?.SetTrigger("Pickup");
        GameStats.Instance.currentCollectedFish ++;
    }

    public void FishInChunk()
    {
        anims?.SetTrigger("Idle");
    }
}
