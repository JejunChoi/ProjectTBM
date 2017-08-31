using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSimilarity : MonoBehaviour {

    public float RetrunSimilarity(bool[,,] missionBlockExist, bool[,,] targetBlockExist, int size)
    {
        int samePartNumber = 0;
        float allPartNumber = size * size * size;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    if (missionBlockExist[x, y, z] == targetBlockExist[x, y, z])
                    {
                        samePartNumber++;
                    }
                }
            }
        }

        return samePartNumber / allPartNumber;
    }
}
