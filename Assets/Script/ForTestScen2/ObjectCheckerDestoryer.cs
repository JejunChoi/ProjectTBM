using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheckerDestoryer : MonoBehaviour {

	void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MotherStatue"))
        {
            Destroy(this.gameObject);
        }
    }

    
}
