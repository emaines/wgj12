﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0.0f, 0.0f, speed);
    }
}
