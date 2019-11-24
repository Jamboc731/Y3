using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ManagerBase<InputManager>
{

    protected float f_xInput, f_zInput;
    protected bool b_jump;

    /// <summary>
    /// Abstract class to handle vague inputs
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// A function for other scripts to call to get a normalised V3 containing the x and z inputs from the player
    /// </summary>
    public virtual Vector3 GetXZInputs()
    {
        return new Vector3(0, 0, 0).normalized;
    }

    /// <summary>
    /// A function for other scripts to call to find if the jump button was pressed
    /// </summary>
    public bool GetJump()
    {
        return b_jump;
    }

}
