using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTargetBlockAndReceiver : MonoBehaviour {

    public GameObject targetBlockMother;
    public GameObject targetBlock;

    public GameObject raycastReceiverX;
    public GameObject raycastReceiverY;
    public GameObject raycastReceiverZ;


    public List<GameObject> StartMaking(int size)
    {
        MakeRaycastReceiver(size);
        return MakeTargetBlocks(size);
    }

    public void MakeRaycastReceiver(int size)
    {
        float lengthCenterToLaycastReceiver;

        lengthCenterToLaycastReceiver = (size + 3) / 2f;



        //generate raycast receiver
        for (int x = 0; x < size; x++)
        {
            var newRaycastReceiverX = Instantiate(raycastReceiverX, targetBlockMother.transform.position + new Vector3(-lengthCenterToLaycastReceiver + 2 + x, -lengthCenterToLaycastReceiver, 0), Quaternion.identity);
            newRaycastReceiverX.transform.localScale = new Vector3(0.9f, 0.9f, size);
            newRaycastReceiverX.name = "RaycastReceiverX" + x.ToString();
        }
        for (int y = 0; y < size; y++)
        {
            var newRaycastReceiverY = Instantiate(raycastReceiverY, targetBlockMother.transform.position + new Vector3(0, -lengthCenterToLaycastReceiver + 2 + y, -lengthCenterToLaycastReceiver), Quaternion.identity);
            newRaycastReceiverY.transform.localScale = new Vector3(size, 0.9f, 0.9f);
            newRaycastReceiverY.name = "RaycastReceiverY" + y.ToString();
        }
        for (int z = 0; z < size; z++)
        {
            var newRaycastReceiverZ = Instantiate(raycastReceiverZ, targetBlockMother.transform.position + new Vector3(-lengthCenterToLaycastReceiver, 0, -lengthCenterToLaycastReceiver + 2 + z), Quaternion.identity);
            newRaycastReceiverZ.transform.localScale = new Vector3(0.9f, size, 0.9f);
            newRaycastReceiverZ.name = "RaycastReceiverZ" + z.ToString();
        }
    }

    public List<GameObject> MakeTargetBlocks(int size)
    {
        Vector3 missionBlockStartPosition = targetBlockMother.transform.position - new Vector3((size - 1) / 2f, (size - 1) / 2f, (size - 1) / 2f);
        List<GameObject> targetBlockList = new List<GameObject>();

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    var newTargetBlock = Instantiate(targetBlock, missionBlockStartPosition + new Vector3(x, y, z), Quaternion.identity);
                    newTargetBlock.transform.parent = targetBlockMother.transform;
                    targetBlockList.Add(newTargetBlock.gameObject);
                }
            }
        }
        return targetBlockList;
    }
   
}
