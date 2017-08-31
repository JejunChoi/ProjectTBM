using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMissionBlock : MonoBehaviour {

    public GameObject missionBlockMother;
    public GameObject missionBlock;

	public void MakeMissionBlocks(int size, bool[,,] missionBlockIsExist)
    {
        Vector3 missionBlockStartPosition = missionBlockMother.transform.position - new Vector3((size - 1) / 2f, (size - 1) / 2f, (size - 1) / 2f);

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    if (missionBlockIsExist[x, y, z])
                    {
                        var newMissionBlock = Instantiate(missionBlock, missionBlockStartPosition + new Vector3(x, y, z), Quaternion.identity);
                        newMissionBlock.transform.parent = missionBlockMother.transform;
                    }
                }
            }
        }
    }
}
