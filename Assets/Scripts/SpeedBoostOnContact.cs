using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostOnContact : MonoBehaviour {

    public float speedBoost = 1.0f;
    private GameObject playerPhysicsGO;
    private CustomPhysics customPhysics;

    void Start()
    {
        playerPhysicsGO = GameObject.Find("Player Physics");
        if(gameObject)
            customPhysics = playerPhysicsGO.GetComponent<CustomPhysics>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boost")
        {
            customPhysics.BoostSpeed(speedBoost);
        }
    }
}
