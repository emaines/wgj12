using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFriction : MonoBehaviour {

    private GameObject playerPhysics;
    private CustomPhysics customPhysics;

    void Start()
    {
        playerPhysics = GameObject.Find("Player Physics");
        if (playerPhysics)
            customPhysics = playerPhysics.GetComponent<CustomPhysics>();
    }

	// Use this for initialization
	void OnTriggerEnter () {
        customPhysics.SetHighFriction(true);
    }

    // Use this for initialization
    void OnTriggerExit()
    {
        customPhysics.SetHighFriction(false);

    }

}
