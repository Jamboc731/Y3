using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    /// <summary>
    /// <param name="f_magnitude">Length of the mesh we'll eventually transform </param>
    /// </summary>
    float f_magnitude;
    /// <summary>
    /// <param name="f_speed">The rate at which we travel along the magnitude</param>
    /// </summary>
    float f_speed;
    /// <summary>
    /// <param name="f_area">The width of the mesh we'll eventually transform</param>
    /// </summary>
    float f_area;
    /// <summary>
    /// <param name="f_linger">How long the mesh will persist until we pool it again </param>
    /// </summary>
    float f_linger;
    /// <summary>
    /// <param name="i_damage">What the fuck do you think this is retard?</param>
    /// </summary>
    int i_damage;
    private void Start()
    {
        i_damage = 1;
    }
}
