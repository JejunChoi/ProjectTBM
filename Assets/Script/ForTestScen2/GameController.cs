using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject makeObjectChecker;
    public GameObject makeMissionBlock;
    public GameObject makeTargetBlock;
    public GameObject getTargetBlockArray;
    public GameObject checkSimilarity;

    MakeObjectCheckerAndReceiver makeObjectCheckerAndReceiverScript;
    MakeMissionBlock makeMissionBlockScript;
    MakeTargetBlockAndReceiver makeTargetBlockAndReceiverScript;
    GetTargetBlockArray getTargetBlockArrayScript;
    CheckSimilarity checkSimilarityScript;

    List<GameObject> targetBlockList = new List<GameObject>();
    bool[,,] missionBlockExist;
    bool[,,] targetBlockExist;
    float similarity;

    public int size;
    int lengthX;
    int lengthY;
    int lengthZ;

    private void Start()
    {
        makeObjectCheckerAndReceiverScript = makeObjectChecker.GetComponent<MakeObjectCheckerAndReceiver>();
        makeMissionBlockScript = makeMissionBlock.GetComponent<MakeMissionBlock>();
        makeTargetBlockAndReceiverScript = makeTargetBlock.GetComponent<MakeTargetBlockAndReceiver>();
        getTargetBlockArrayScript = getTargetBlockArray.GetComponent<GetTargetBlockArray>();
        checkSimilarityScript = checkSimilarity.GetComponent<CheckSimilarity>();
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        makeObjectCheckerAndReceiverScript.StartMaking(size);
        yield return new WaitForSeconds(1f);
        missionBlockExist = makeObjectCheckerAndReceiverScript.boxShouldNotExist;
        makeMissionBlockScript.MakeMissionBlocks(size, missionBlockExist);
        targetBlockList = makeTargetBlockAndReceiverScript.StartMaking(size);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetBlockExist = getTargetBlockArrayScript.TransformDataType(targetBlockList, size);
            similarity = checkSimilarityScript.RetrunSimilarity(missionBlockExist, targetBlockExist, size);
            Debug.Log(similarity);
        }
    }
}
