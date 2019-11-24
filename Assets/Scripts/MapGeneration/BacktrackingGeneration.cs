using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public static int[][][] iA3_space;
    /// <summary>
    /// <param name="v3A_previousMoves">
    /// The previous spaces that the algorithm visited
    /// </param>
    /// </summary>
    private static List<Vector3> v3A_previousMoves = new List<Vector3>();
    /// <summary>
    /// <param name="v3)currentPosition">The current position in local space that the algorithm is</param>
    /// </summary>
    private static Vector3 v3_currentPosition;
    /// <summary>
    /// <param name="v3A_neighbourVectors">The vecotrs that are adjacent to the current position</param>
    /// </summary>
    private static Vector3[] v3A_neighbourVectors = new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0), new Vector3(0, -1, 0), new Vector3(0, 1, 0), new Vector3(0, 0, -1), new Vector3(0, 0, 1) };
    public static bool done = false;

    /// <summary>
    /// This function will return the generated pathway given dimensions
    /// </summary>
    /// <param name="_i_xSize">The x size of the space</param>
    /// <param name="_i_ySize">The y size of the space</param>
    /// <param name="_i_zSize">The z size of the space</param>
    /// <returns></returns>
    public static int[][][] Generate(int _i_xSize, int _i_ySize, int _i_zSize)
    {

        InitialiseSpace(_i_xSize, _i_ySize, _i_zSize);
        Step();

        return iA3_space;
    }

    public static int[][][] GetPath()
    {
        return iA3_space;
    }

    public static IEnumerator hmm()
    {
        done = false;
        int i = 0;
        while (v3A_previousMoves.Count > 0)
        {
            Debug.Log("on step: " + i + " of max: " + iA3_space.Length * iA3_space[0].Length * iA3_space[0][0].Length + " | " + v3A_previousMoves.Count);
            yield return new WaitForSeconds(Time.deltaTime);
            i++;
            Step();
        }
        done = true;
    }

    /// <summary>
    /// A function to initialise the local space array for the pathway
    /// </summary>
    /// <param name="_i_xSize">The x size of the space</param>
    /// <param name="_i_ySize">The y size of the space</param>
    /// <param name="_i_zSize">The z size of the space</param>
    private static void InitialiseSpace(int _i_xSize, int _i_ySize, int _i_zSize)
    {
        int i_width = _i_xSize;
        int i_height = _i_ySize;
        int i_length = _i_zSize;

        iA3_space = new int[i_width][][];

        // populate a 3d array of ints with 0's
        for (int i = 0; i < i_width; i++)
        {
            iA3_space[i] = new int[i_height][];
            for (int j = 0; j < i_height; j++)
            {
                iA3_space[i][j] = new int[i_length];
                for (int k = 0; k < _i_zSize; k++)
                {
                    iA3_space[i][j][k] = 0;
                }
            }
        }

    }

    /// <summary>
    /// Checks the spaces around a given position
    /// </summary>
    /// <param name="_v3_inQuestion">The vector to check the neighbours of</param>
    /// <param name="_i_depth">the depth at which it will search through the neighbours of the neighbours</param>
    private static Vector3[] CheckNeighbours(Vector3 _v3_inQuestion, int _i_depth)
    {
        List<Vector3> v3L_validMoves = new List<Vector3>(); //the list of valid moves
        Vector3Int cur; //the current position under examination

        for (int i = 0; i < v3A_neighbourVectors.Length; i++) //loop through all neighbours
        {
            cur = Vector3Int.CeilToInt(_v3_inQuestion + v3A_neighbourVectors[i]); //set current position

            try
            {
                if(iA3_space[cur.x][cur.y][cur.z] == 0) //if the space is empty
                {
                    if (_i_depth > 0) //should i check its neighbours?
                    {
                        if (CheckNeighbours(cur, _i_depth - 1).Length >= 3) v3L_validMoves.Add(cur); //check its neighbours and if it has more that 2 empty spaces next 2 it then add it to the list
                    }
                    else v3L_validMoves.Add(cur); //add it to the list of available spaces
                }
            }
            catch { continue; }

        }

        return v3L_validMoves.ToArray();

    }

    /// <summary>
    /// Moves the current position in a random direction where it will not make loops or cycles
    /// </summary>
    private static void Step()
    {
        Vector3[] v3_availableSpaces = CheckNeighbours(v3_currentPosition, 0);

        if (v3_availableSpaces.Length > 0)
        {
            //Debug.Log(v3_availableSpaces.Length);
            v3A_previousMoves.Add(v3_currentPosition);
            iA3_space[(int)v3_currentPosition.x][(int)v3_currentPosition.y][(int)v3_currentPosition.z] = 1;
            v3_currentPosition = v3_availableSpaces[Random.Range(0, v3_availableSpaces.Length)];
        }
        else
        {
            Backtrack();
        }
    }

    private static bool Backtrack()
    {

        v3_currentPosition = v3A_previousMoves.Last();
        if(v3A_previousMoves.Count > 0)
        {
            v3A_previousMoves.RemoveAt(v3A_previousMoves.Count - 1);
            return true;
        }
        return false;
    }

}
