using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject cube;

    int[][][] path;

    private void Start()
    {
        path = BacktrackingGeneration.Generate(10, 1, 10);
        StartCoroutine(BacktrackingGeneration.hmm());

        StartCoroutine(CheckIfDone());
    }

    IEnumerator CheckIfDone()
    {
        while (!BacktrackingGeneration.done)
        {
            yield return new WaitForSeconds(1);
        }
        path = BacktrackingGeneration.GetPath();
        for (int i = 0; i < path.Length; i++)
        {
            for (int j = 0; j < path[i].Length; j++)
            {
                for (int k = 0; k < path[i][j].Length; k++)
                {
                    if (path[i][j][k] == 1)
                    {
                        Instantiate(cube, new Vector3(i, j, k), Quaternion.identity);
                    }
                }
            }
        }
    }

}
