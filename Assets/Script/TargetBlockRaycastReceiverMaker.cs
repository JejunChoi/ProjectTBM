using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlockRaycastReceiverMaker : MonoBehaviour
{

    public GameObject blockSize;
    public GameObject targetBlockMother;
    public GameObject raycastReceiverX;
    public GameObject raycastReceiverY;
    public GameObject raycastReceiverZ;

    int size;
    int lengthX;
    int lengthY;
    int lengthZ;
    Vector3 startGeneratePosition= new Vector3();

    void Start()
    {
        size = blockSize.GetComponent<BlockSize>().size;
        lengthX = size;
        lengthY = size;
        lengthZ = size;

        GenerateTargetRaycastReceiver();
    }

    public void GenerateTargetRaycastReceiver()
    {
        float lengthCenterLaycastReceiverX;
        float lengthCenterLaycastReceiverY;
        float lengthCenterLaycastReceiverZ;

        if (size % 2 == 0)
        {
            startGeneratePosition = targetBlockMother.transform.position - new Vector3((lengthX - 1) / 2f, (lengthY - 1) / 2f, (lengthZ - 1) / 2f);
            lengthCenterLaycastReceiverX = (lengthX + 3) / 2f;
            lengthCenterLaycastReceiverY = (lengthY + 3) / 2f;
            lengthCenterLaycastReceiverZ = (lengthZ + 3) / 2f;
        }
        else
        {
            startGeneratePosition = targetBlockMother.transform.position - new Vector3(lengthX / 2f, lengthY / 2f, lengthZ / 2f);
            lengthCenterLaycastReceiverX = (lengthX + 4) / 2f;
            lengthCenterLaycastReceiverY = (lengthY + 4) / 2f;
            lengthCenterLaycastReceiverZ = (lengthZ + 4) / 2f;
        }

        //generate raycast receiver
        for (int x = 0; x < lengthX; x++)
        {
            var newRaycastReceiverX = Instantiate(raycastReceiverX, targetBlockMother.transform.position + new Vector3(-lengthCenterLaycastReceiverX + 2 + x, -lengthCenterLaycastReceiverY, 0), Quaternion.identity);
            newRaycastReceiverX.transform.localScale = new Vector3(0.9f, 0.9f, lengthX);
            newRaycastReceiverX.name = "RaycastReceiverX" + x.ToString();
        }
        for (int y = 0; y < lengthY; y++)
        {
            var newRaycastReceiverY = Instantiate(raycastReceiverY, targetBlockMother.transform.position + new Vector3(0, -lengthCenterLaycastReceiverY + 2 + y, -lengthCenterLaycastReceiverZ), Quaternion.identity);
            newRaycastReceiverY.transform.localScale = new Vector3(lengthY, 0.9f, 0.9f);
            newRaycastReceiverY.name = "RaycastReceiverY" + y.ToString();
        }
        for (int z = 0; z < lengthY; z++)
        {
            var newRaycastReceiverZ = Instantiate(raycastReceiverZ, targetBlockMother.transform.position + new Vector3(-lengthCenterLaycastReceiverX, 0, -lengthCenterLaycastReceiverZ + 2 + z), Quaternion.identity);
            newRaycastReceiverZ.transform.localScale = new Vector3(0.9f, lengthZ, 0.9f);
            newRaycastReceiverZ.name = "RaycastReceiverZ" + z.ToString();
        }
    }
}

