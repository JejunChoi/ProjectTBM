using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCheckerMaker : MonoBehaviour
{

    public GameObject checkCollider;
    public GameObject sourceObject;
    public GameObject raycastReceiverX;
    public GameObject raycastReceiverY;
    public GameObject raycastReceiverZ;
    public GameObject missionBlockGenerator;
    public GameObject targetBlockGenerator;
    public GameObject blockSize;

    List<Dictionary<string, string>> missionCheckerPosition = new List<Dictionary<string, string>>();

    int size;
    int lengthX;
    int lengthY;
    int lengthZ;

    Vector3 startGeneratePosition;

    MissionBlockGenerator MBGScript;
    TargetBlockGenerator TBGScript;
    void Start()
    {
        size = blockSize.GetComponent<BlockSize>().size;
        MBGScript = missionBlockGenerator.GetComponent<MissionBlockGenerator>();
        TBGScript = targetBlockGenerator.GetComponent<TargetBlockGenerator>();
        lengthX = size;
        lengthY = size;
        lengthZ = size;
       

        StartCoroutine(GenerateMissionCheckCollider());

    }

    IEnumerator GenerateMissionCheckCollider()
    {
        float lengthCenterLaycastReceiverX;
        float lengthCenterLaycastReceiverY;
        float lengthCenterLaycastReceiverZ;
     
        if (size % 2 == 0)
        {
            startGeneratePosition = sourceObject.transform.position - new Vector3((lengthX - 1) / 2f, (lengthY - 1) / 2f, (lengthZ - 1) / 2f);
            lengthCenterLaycastReceiverX = (lengthX + 3) / 2f;
            lengthCenterLaycastReceiverY = (lengthY + 3) / 2f;
            lengthCenterLaycastReceiverZ = (lengthZ + 3) / 2f;
        }
        else
        {
            startGeneratePosition = sourceObject.transform.position - new Vector3(lengthX / 2f, lengthY / 2f, lengthZ / 2f);
            lengthCenterLaycastReceiverX = (lengthX + 4) / 2f;
            lengthCenterLaycastReceiverY = (lengthY + 4) / 2f;
            lengthCenterLaycastReceiverZ = (lengthZ + 4) / 2f;
        }

        //generate raycast receiver
        for (int x = 0; x < lengthX; x++)
        {
            var newRaycastReceiverX = Instantiate(raycastReceiverX, sourceObject.transform.position + new Vector3(-lengthCenterLaycastReceiverX +2+ x, -lengthCenterLaycastReceiverY, 0), Quaternion.identity);
            newRaycastReceiverX.transform.localScale = new Vector3(0.9f, 0.9f, lengthX);
            newRaycastReceiverX.name = "RaycastReceiverX"+x.ToString();
        }
        for (int y = 0; y < lengthY; y++)
        {
            var newRaycastReceiverY = Instantiate(raycastReceiverY, sourceObject.transform.position + new Vector3(0, -lengthCenterLaycastReceiverY+2+ y, -lengthCenterLaycastReceiverZ), Quaternion.identity);
            newRaycastReceiverY.transform.localScale = new Vector3(lengthY, 0.9f, 0.9f);
            newRaycastReceiverY.name = "RaycastReceiverY" + y.ToString();
        }
        for (int z = 0; z < lengthY; z++)
        {
            var newRaycastReceiverZ= Instantiate(raycastReceiverZ, sourceObject.transform.position + new Vector3(-lengthCenterLaycastReceiverX, 0, -lengthCenterLaycastReceiverZ +2+ z), Quaternion.identity);
            newRaycastReceiverZ.transform.localScale = new Vector3(0.9f, lengthZ, 0.9f);
            newRaycastReceiverZ.name = "RaycastReceiverZ" + z.ToString();
        }

        //generate block
        List<GameObject> newcheckColliderList = new List<GameObject>();
        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int z = 0; z < lengthZ; z++)
                {
                    var newcheckCollider = Instantiate(checkCollider, startGeneratePosition + new Vector3(x, y, z), Quaternion.identity);
                    newcheckColliderList.Add(newcheckCollider.transform.gameObject);
                }
            }
        }

        yield return null;//Never Destroy It. It is used to wait that undesired gameObject is destoried by other script;
        yield return null;

        RaycastForFindingRaycastReceiver newcheckColliderScript;
        for (int i = 0; i < newcheckColliderList.Count; i++)
        {
            if (newcheckColliderList[i].gameObject != null)
            {
                newcheckColliderScript = newcheckColliderList[i].GetComponent<RaycastForFindingRaycastReceiver>();
                Dictionary<string, string> hitRaycastReceiver = newcheckColliderScript.raycastReceiverChecker();
                missionCheckerPosition.Add(hitRaycastReceiver);
            }
        }

        MBGScript.MakeMissionBlock(missionCheckerPosition);
        TBGScript.MakeTargetBlock();
    }

}