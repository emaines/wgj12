using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostOnContact : MonoBehaviour {

    public float speedBoost = 1.0f;
    public float jumpImpulse = 1000.0f;
    private Rigidbody playerRigidBody;
    private GameObject playerPhysicsGO;
    private CustomPhysics customPhysics;

    void Start()
    {
        playerPhysicsGO = GameObject.Find("Player Physics");
        if (gameObject) {
            customPhysics = playerPhysicsGO.GetComponent<CustomPhysics>();
            playerRigidBody = playerPhysicsGO.GetComponentInParent<Rigidbody>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boost")
        {
            customPhysics.BoostSpeed(speedBoost);
            //Vector3 toCenterVector = Vector3.zero - playerRigidBody.transform.position;
            //playerRigidBody.AddForce(new Vector3(toCenterVector.x, jumpImpulse, toCenterVector.z), ForceMode.Impulse);
            playerRigidBody.AddForce(new Vector3(0.0f, jumpImpulse, 0.0f), ForceMode.Acceleration);

        }
    }
}
