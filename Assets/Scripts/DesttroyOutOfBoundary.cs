using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesttroyOutOfBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if(other.tag != "Player")
        {
            Destroy(other.gameObject, 1.0f);
        }
    }
}
