using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlockGenerator : MonoBehaviour
{

    public GameObject targetBlock;
    public GameObject targetBlockMother;
    public GameObject blockSize;


    int size;
    int lengthX;
    int lengthY;
    int lengthZ;
    Vector3 startGeneratePosition;

    public void MakeTargetBlock()
    {
        size = blockSize.GetComponent<BlockSize>().size;
        lengthX = size;
        lengthY = size;
        lengthZ = size;
        
        GenerateTargetBlockCoroutine();

    }

    public void GenerateTargetBlockCoroutine()
    {
        StartCoroutine(GenerateTargetBlock());
    }

    IEnumerator GenerateTargetBlock()
    {
        if (size % 2 == 0)
        {
            startGeneratePosition = targetBlockMother.transform.position - new Vector3((lengthX - 1) / 2f, (lengthY - 1) / 2f, (lengthZ - 1) / 2f);
        }
        else
        {
            startGeneratePosition = targetBlockMother.transform.position - new Vector3(lengthX / 2f, lengthY / 2f, lengthZ / 2f);
        }

        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                for (int z = 0; z < lengthZ; z++)
                {
                    var newtargetBlock = Instantiate(targetBlock, startGeneratePosition + new Vector3(x, y, z), Quaternion.identity);
                    newtargetBlock.transform.parent = targetBlockMother.transform;
                }
                yield return null;
            }
        }


        ObjectRotator targetObjectRotator = targetBlockMother.GetComponent<ObjectRotator>();
        targetObjectRotator.enabled = true;
        targetObjectRotator.RotationAxisX = true;

    }
}
