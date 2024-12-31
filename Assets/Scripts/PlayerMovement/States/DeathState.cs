using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    [SerializeField] private Vector3 knockbackForce = new Vector3(0, 4, -3);
    private Vector3 currentKnockback;
    public override void EnterState()
    {
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
            Invoke("PostDeathAction", 1.0f);
        }

        return currentKnockback;
    }
    void PostDeathAction()
    {
        GameManager.Instance.ChangeState(GameManager.Instance.GetComponent<PostDeathState>());
    }
}
