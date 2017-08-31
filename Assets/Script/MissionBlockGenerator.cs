using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBlockGenerator : MonoBehaviour
{

    public GameObject missionBlock;
    public GameObject missionBlockMother;
    public GameObject blockSize;
    

    int size;
    int lengthX;
    int lengthY;
    int lengthZ;
    Vector3 startGeneratePosition;
    public bool[,,] IsExist;

    public void MakeMissionBlock(List<Dictionary<string, string>> missionCheckerPosition)
    {
        size = blockSize.GetComponent<BlockSize>().size;
        lengthX = size;
        lengthY = size;
        lengthZ = size;
        IsExist = new bool[lengthX, lengthY, lengthZ];

        GenerateMissionBlockCoroutine(missionCheckerPosition);
        
    }

    public void GenerateMissionBlockCoroutine(List<Dictionary<string, string>> missionCheckerPosition)
    {
        StartCoroutine(GenerateMissionBlock(missionCheckerPosition));
    }

    IEnumerator GenerateMissionBlock(List<Dictionary<string, string>> missionCheckerPosition)
    {
        if (size % 2 == 0)
        {
            startGeneratePosition = missionBlockMother.transform.position - new Vector3((lengthX - 1) / 2f, (lengthY - 1) / 2f, (lengthZ - 1) / 2f);
        }
        else
        {
            startGeneratePosition = missionBlockMother.transform.position - new Vector3(lengthX / 2f, lengthY / 2f, lengthZ / 2f);
        }

        //Initailize array
        
        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int z = 0; z < lengthZ; z++)
                {
                    IsExist[x,y,z] = true;
                }
            }
        }

        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int z = 0; z < lengthZ; z++)
                {
                    for (int i = 0; i < missionCheckerPosition.Count; i++) {
                        if (missionCheckerPosition[i]["X"] == "RaycastReceiverX" + x.ToString() && missionCheckerPosition[i]["Y"] == "RaycastReceiverY" + y.ToString() && missionCheckerPosition[i]["Z"] == "RaycastReceiverZ" + z.ToString())
                        {
                            IsExist[x,y,z] = false;
                        }
                    }
                }
            }
        }

        //Mission Block 생성
        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int z = 0; z < lengthZ; z++)
                {
                    if (IsExist[x,y,z] == true)
                    {
                        var newMissionBlock = Instantiate(missionBlock, startGeneratePosition + new Vector3(x, y, z), Quaternion.identity);
                        newMissionBlock.transform.parent = missionBlockMother.transform;
                    }
                }
                yield return null;
            }
        }


        ObjectRotator MissionObjectRotator = missionBlockMother.GetComponent<ObjectRotator>();
        MissionObjectRotator.enabled = true;
        MissionObjectRotator.RotationAxisX = true;
        
    }
}
