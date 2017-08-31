using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetBlockArray : MonoBehaviour {

	public bool[,,] TransformDataType(List<GameObject>targetBlockList, int size)
    {
        bool[,,] targetBlockExist = new bool[size, size, size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    targetBlockExist[x, y, z] = false;
                }
            }
        }

        foreach (GameObject targetblock in targetBlockList)
        {
            if (targetblock.gameObject != null)
            {
                int tempX = 0;
                int tempY = 0;
                int tempZ = 0;
                RaycastForFindingRaycastReceiver raycastForFindingRaycastReceiverScript = targetblock.gameObject.GetComponent<RaycastForFindingRaycastReceiver>();
                Dictionary<string, string> hitRaycastReceiver = raycastForFindingRaycastReceiverScript.raycastReceiverChecker();
                for (int x = 0; x < size; x++)
                {
                    if (hitRaycastReceiver["X"] == "RaycastReceiverX" + x.ToString())
                    {
                        tempX = x;
                        break;
                    }
                }
                for (int y = 0; y < size; y++)
                {
                    if (hitRaycastReceiver["Y"] == "RaycastReceiverY" + y.ToString())
                    {
                        tempY = y;
                        break;
                    }
                }
                for (int z = 0; z < size; z++)
                {
                    if (hitRaycastReceiver["Z"] == "RaycastReceiverZ" + z.ToString())
                    {
                        tempZ = z;
                        break;
                    }
                }
                targetBlockExist[tempX, tempY, tempZ] = true;
            }
        }
        return targetBlockExist;
    }
}
