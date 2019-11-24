using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <param name="BacktrackingGeneration">
/// A class containing the functions to generate a random branching pathway using a recursive backtracking algorithm
/// </param>
/// </summary>
public class BacktrackingGeneration
{
    /// <summary>
    /// <param name="i3A_space">The space that the pathway exists in</param>
    /// </summary>
    /// <returns></returns>
    private int[][][] iA3_space;
    /// <summary>
    /// <param name="v3A_previousMoves">
    /// The previous spaces that the algorithm visited
    /// </param>
    /// </summary>
    private List<Vector3> v3A_previousMoves = new List<Vector3>();

    /// <summary>
    /// This function will return the generated pathway given dimensions
    /// </summary>
    /// <param name="_i_xSize">The x size of the space</param>
    /// <param name="_i_ySize">The y size of the space</param>
    /// <param name="_i_zSize">The z size of the space</param>
    /// <returns></returns>
    public int[][][] Generate(int _i_xSize, int _i_ySize, int _i_zSize)
    {

        InitialiseSpace(_i_xSize, _i_ySize, _i_zSize);



        return iA3_space;
    }

    /// <summary>
    /// A function to initialise the local space array for the pathway
    /// </summary>
    /// <param name="_i_xSize">The x size of the space</param>
    /// <param name="_i_ySize">The y size of the space</param>
    /// <param name="_i_zSize">The z size of the space</param>
    private void InitialiseSpace(int _i_xSize, int _i_ySize, int _i_zSize)
    {
        int i_width = _i_xSize;
        int i_height = _i_ySize;
        int i_length = _i_zSize;

        iA3_space = new int[i_width][][];

        for (int i = 0; i < i_width; i++)
        {
            iA3_space[i] = new int[i_height][];
            for (int j = 0; j < i_height; j++)
            {
                iA3_space[i][j] = new int[i_length];
            }
        }
    }

    //public void 

}
