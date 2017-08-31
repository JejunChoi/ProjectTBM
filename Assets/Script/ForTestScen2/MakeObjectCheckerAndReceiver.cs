using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectCheckerAndReceiver : MonoBehaviour
{

    public GameObject checkCollider;
    public GameObject motherStatue;
    public GameObject raycastReceiverX;
    public GameObject raycastReceiverY;
    public GameObject raycastReceiverZ;

    Vector3 objectCheckerStartPosition;
    public bool[,,] boxShouldNotExist;

    public void StartMaking(int size)
    {
        MakeRaycastReceiver(size);
        StartCoroutine(MakeObjectCheckerBox(size));
    }

    public void MakeRaycastReceiver(int size)
    {
        float lengthCenterToLaycastReceiver;

        lengthCenterToLaycastReceiver = (size + 3) / 2f;



        //generate raycast receiver
        for (int x = 0; x < size; x++)
        {
            var newRaycastReceiverX = Instantiate(raycastReceiverX, motherStatue.transform.position + new Vector3(-lengthCenterToLaycastReceiver + 2 + x, -lengthCenterToLaycastReceiver, 0), Quaternion.identity);
            newRaycastReceiverX.transform.localScale = new Vector3(0.9f, 0.9f, size);
            newRaycastReceiverX.name = "RaycastReceiverX" + x.ToString();
        }
        for (int y = 0; y < size; y++)
        {
            var newRaycastReceiverY = Instantiate(raycastReceiverY, motherStatue.transform.position + new Vector3(0, -lengthCenterToLaycastReceiver + 2 + y, -lengthCenterToLaycastReceiver), Quaternion.identity);
            newRaycastReceiverY.transform.localScale = new Vector3(size, 0.9f, 0.9f);
            newRaycastReceiverY.name = "RaycastReceiverY" + y.ToString();
        }
        for (int z = 0; z < size; z++)
        {
            var newRaycastReceiverZ = Instantiate(raycastReceiverZ, motherStatue.transform.position + new Vector3(-lengthCenterToLaycastReceiver, 0, -lengthCenterToLaycastReceiver + 2 + z), Quaternion.identity);
            newRaycastReceiverZ.transform.localScale = new Vector3(0.9f, size, 0.9f);
            newRaycastReceiverZ.name = "RaycastReceiverZ" + z.ToString();
        }
    }

    public IEnumerator MakeObjectCheckerBox(int size)
    {
        boxShouldNotExist = new bool[size, size, size];
        List<GameObject> checkColliderList = new List<GameObject>();
        objectCheckerStartPosition = motherStatue.transform.position - new Vector3((size-1) / 2f, (size -1)/ 2f, (size-1) / 2f);

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    var newCheckCollider = Instantiate(checkCollider, objectCheckerStartPosition + new Vector3(x, y, z), Quaternion.identity);
                    checkColliderList.Add(newCheckCollider.gameObject);
                    boxShouldNotExist[x,y,z] = true;
                }
            }
        }

        yield return null;
        yield return null;

        foreach (GameObject checkCollider in checkColliderList)
        {
            if (checkCollider.gameObject != null)
            {
                int tempX=0;
                int tempY=0;
                int tempZ=0;
                RaycastForFindingRaycastReceiver raycastForFindingRaycastReceiverScript = checkCollider.gameObject.GetComponent<RaycastForFindingRaycastReceiver>();
                Dictionary<string, string> hitRaycastReceiver = raycastForFindingRaycastReceiverScript.raycastReceiverChecker();
                for(int x=0; x < size; x++)
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
                boxShouldNotExist[tempX, tempY, tempZ] = false;
            }
        }
    }
}

