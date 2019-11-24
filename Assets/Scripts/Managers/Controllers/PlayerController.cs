using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : InputManager
{
    /// <summary>
    /// <param name="player">Sugma</param>
    /// </summary>
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        b_jump = false;

        b_jump = Input.GetButtonDown("Jump");

        f_xInput = player.GetAxis("XInput");
        f_zInput = player.GetAxis("ZInput");
    }

    public override Vector3 GetXZInputs()
    {
        return new Vector3(f_xInput, 0, f_zInput).normalized;
    }
}
