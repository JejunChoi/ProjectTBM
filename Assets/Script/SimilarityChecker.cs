using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimilarityChecker : MonoBehaviour {


    public GameObject missionCheckerMaker;
    public GameObject targetBlockMother;
    public MissionBlockGenerator missionBlockGenerator;
    public GameObject blockSize;
    
    bool[,,] IsNowExist;
    bool[,,] IsMission;

    int size;
    int lengthX;
    int lengthY;
    int lengthZ;

    int NumberOfSameBlock;
    float NumberOfAllBlock;
    float Similarity;

    bool IsGameMode;
    private void Start()
    {
        IsGameMode = true;
        size = blockSize.GetComponent<BlockSize>().size;
        lengthX = size;
        lengthY = size;
        lengthZ = size;
        IsNowExist = new bool[lengthX, lengthY, lengthZ];
        IsMission = new bool[lengthX, lengthY, lengthZ];
        NumberOfAllBlock = size * size * size;
        NumberOfSameBlock = 0;
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1) && IsGameMode)
        {
            IsGameMode = false;
            StopRotation();
            CheckSimilarity();
        }
	}

    public void StopRotation()
    {
        targetBlockMother.GetComponent<ObjectRotator>().enabled=false;
        targetBlockMother.transform.rotation = Quaternion.identity;
    }

    public void CheckSimilarity()
    {
        //IsNowExist초기화
        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int z = 0; z < lengthZ; z++)
                {
                    IsNowExist[x, y, z] = false;
                }
            }
        }

        List<Dictionary<string, string>> targetPosition = new List<Dictionary<string, string>>();
        Transform[] targetBlocks = targetBlockMother.GetComponentsInChildren<Transform>();
        Debug.Log(targetBlocks[2]);
        for (int i = 0;i<targetBlocks.Length;i++)
        {
            RaycastForFindingRaycastReceiver targetBlockRaycastReceiverScript = targetBlocks[i].gameObject.GetComponent<RaycastForFindingRaycastReceiver>();
            Dictionary<string, string> hitRaycastReceiver 
                = targetBlockRaycastReceiverScript.raycastReceiverChecker();
            targetPosition.Add(hitRaycastReceiver);
        }

        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int z = 0; z < lengthZ; z++)
                {
                    for (int i = 0; i < targetPosition.Count; i++)
                    {
                        if (targetPosition[i]["X"] == "RaycastReceiverX" + x.ToString() && targetPosition[i]["Y"] == "RaycastReceiverY" + y.ToString() && targetPosition[i]["Z"] == "RaycastReceiverZ" + z.ToString())
                        {
                            IsNowExist[x, y, z] = true;
                        }
                    }
                }
            }
        }

        
        IsMission = missionBlockGenerator.IsExist;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    if (IsNowExist[x, y, z] != IsMission[x, y, z])
                    {
                        NumberOfSameBlock++;
                    }
                }
            }
        }

        Similarity = NumberOfSameBlock / NumberOfAllBlock;
        Debug.Log(Similarity);
    }
}
