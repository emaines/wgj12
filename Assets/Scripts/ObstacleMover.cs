using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour {

    private Rigidbody rb;
    private GameObject playerPhysics;
    private CustomPhysics customPhysics;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPhysics = GameObject.Find("Player Physics");
        if (playerPhysics)
            customPhysics = playerPhysics.GetComponent<CustomPhysics>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0.0f, 0.0f, -customPhysics.Speed());
    }
}
