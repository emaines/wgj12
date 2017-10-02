using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {


    public float tileSizeZ;

    private Vector3 startPosition;

    private GameObject playerPhysics;
    private CustomPhysics customPhysics;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        playerPhysics = GameObject.Find("Player Physics");
        if (playerPhysics)
            customPhysics = playerPhysics.GetComponent<CustomPhysics>();
    }
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * -customPhysics.Speed(), tileSizeZ);
        //Debug.Log("Time*speed" + Time.time * -customPhysics.Speed());
        //Debug.Log(newPosition);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
