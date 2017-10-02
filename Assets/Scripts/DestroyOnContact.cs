using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fatal")
            Destroy(other.gameObject, .5f);
    }
}
