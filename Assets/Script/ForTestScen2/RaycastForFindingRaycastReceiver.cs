using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForFindingRaycastReceiver : MonoBehaviour
{

    public RaycastHit hitX;
    public RaycastHit hitY;
    public RaycastHit hitZ;
    

    public Dictionary<string, string> raycastReceiverChecker()
    {
        Dictionary<string, string> hitRaycastReceiver = new Dictionary<string, string>();

        RaycastHit[] hitsX;
        hitsX = Physics.RaycastAll(transform.position, new Vector3(0, -1f, 0), 50, 1 << LayerMask.NameToLayer("RaycastReceiver"));
        if (hitsX.Length != 0)
        {
            hitX = hitsX[0];
            hitRaycastReceiver.Add("X", hitX.transform.gameObject.name);
        }
        else
        {
            Debug.Log("there is no object collide with receiverX");
        }


        RaycastHit[] hitsY;
        hitsY = Physics.RaycastAll(transform.position, new Vector3(0, 0, -1f), 50, 1 << LayerMask.NameToLayer("RaycastReceiver"));
        if (hitsY.Length != 0)
        {
            hitY = hitsY[0];
            hitRaycastReceiver.Add("Y", hitY.transform.gameObject.name);
        }
        else
        {
            Debug.Log("there is no object collide with receiverY");
        }

        RaycastHit[] hitsZ;
        hitsZ = Physics.RaycastAll(transform.position, new Vector3(-1f, 0, 0), 50, 1 << LayerMask.NameToLayer("RaycastReceiver"));
        if (hitsZ.Length != 0)
        {
            hitZ = hitsZ[0];
            hitRaycastReceiver.Add("Z", hitZ.transform.gameObject.name);
        }
        else
        {
            Debug.Log("there is no object collide with receiverZ");
        }

        return hitRaycastReceiver;
    }

    //private void Update()
    //{
    //    Debug.DrawRay(transform.position, new Vector3(0, -50, 0), Color.red);
    //    Debug.DrawRay(transform.position, new Vector3(0, 0, -50), Color.green);
    //    Debug.DrawRay(transform.position, new Vector3(-50, 0, 0), Color.blue);
    //}
}
