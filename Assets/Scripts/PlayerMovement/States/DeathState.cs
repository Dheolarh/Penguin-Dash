using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    [SerializeField] private Vector3 knockbackForce = new Vector3(0, 4, -3);
    private Vector3 currentKnockback;
    public override void EnterState()
    {
        if (SaveManager.Instance.saveData.Debugger)
        {
            GameStats.Instance.totalCollectedFish = GameStats.Instance.currentCollectedFish;
            SaveManager.Instance.saveData.Fish = GameStats.Instance.totalCollectedFish;
            SaveManager.Instance.saveData.Debugger = false;
        }
        else
        {
            Debug.Log($"Total: {GameStats.Instance.totalCollectedFish}");
            Debug.Log($"Current: {GameStats.Instance.currentCollectedFish}");
            GameStats.Instance.totalCollectedFish = GameStats.Instance.currentCollectedFish;
            SaveManager.Instance.saveData.Fish += GameStats.Instance.totalCollectedFish;
        }
        _movement.deathDebug = false;
       _movement.animator?.SetTrigger("Death");
       currentKnockback = knockbackForce;
    }
    
    public override Vector3 StartState()
    {
        Vector3 m = currentKnockback;

        currentKnockback = new Vector3(
            0,
            currentKnockback.y -= _movement.gravity * Time.deltaTime,
            currentKnockback.z += 2.0f * Time.deltaTime);

        if (currentKnockback.z > 0)
        {
            currentKnockback.z = 0;
        }
        return currentKnockback;
    }

    public override void UpdateState()
    {
        if (currentKnockback.z >= 0)
        {
            Invoke("PostDeathAction", 0.1f);
        }
    }

    void PostDeathAction()
    {
        _movement.ChangeState(_movement.GetComponent<GameResetState>());
    }
}
