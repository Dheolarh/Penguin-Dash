using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnState : BaseState
{
    [SerializeField] private float verticalHeight;
    // Start is called before the first frame update
    public override void EnterState()
    {
        _movement.jumpCount = 0;
        _movement.controller.enabled = false;
        _movement.transform.position = new Vector3(
            0,
            verticalHeight,
            _movement.playerTransform.position.z);
        _movement.controller.enabled = true;
        _movement.ChangeState(GetComponent<FallingState>());
    }
}
