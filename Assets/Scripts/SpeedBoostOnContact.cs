using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostOnContact : MonoBehaviour {

    public float speedBoost = 1.0f;
    public float speedSlow = 1.0f;
    public float jumpImpulse = 1000.0f;
    private Rigidbody playerRigidBody;
    private GameObject playerPhysicsGO;
    private CustomPhysics customPhysics;

    private GameObject gameDirectorObject;
    private GameDirector gameDirector;

    void Start()
    {
        playerPhysicsGO = GameObject.Find("Player Physics");
        if (gameObject) {
            customPhysics = playerPhysicsGO.GetComponent<CustomPhysics>();
            playerRigidBody = playerPhysicsGO.GetComponentInParent<Rigidbody>();
        }

        gameDirectorObject = GameObject.Find("Game Manager");
        if (gameDirectorObject)
            gameDirector = gameDirectorObject.GetComponent<GameDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boost")
        {
            customPhysics.BoostSpeed(speedBoost);
            playerRigidBody.AddForce(new Vector3(0.0f, jumpImpulse, 0.0f), ForceMode.Acceleration);
            gameDirector.AddPoints(10);
        }
        if (other.tag == "SlowDown")
        {
            customPhysics.BoostSpeed(-speedSlow);
            gameDirector.AddPoints(-5);
        }
        if (other.tag == "Fatal")
        {
            customPhysics.BoostSpeed(-speedSlow);
            gameDirector.AddPoints(50);
        }
    }
}
