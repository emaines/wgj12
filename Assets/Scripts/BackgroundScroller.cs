using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {


    public float tileSizeZ;

    private Vector3 startPosition;

    private GameObject playerPhysics;
    private CustomPhysics customPhysics;
    private float newPosition;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        playerPhysics = GameObject.Find("Player Physics");
        if (playerPhysics)
            customPhysics = playerPhysics.GetComponent<CustomPhysics>();
    }
	
	// Update is called once per frame
	void Update () {
        //float newPosition = Mathf.Repeat(Time.deltaTime * customPhysics.Speed(), tileSizeZ);
        newPosition = newPosition + customPhysics.Speed() * Time.deltaTime;
        newPosition = Mathf.Repeat(newPosition, tileSizeZ);

        //Debug.Log("Time*speed" + Time.time * customPhysics.Speed());
        //Debug.Log(newPosition);
        //Debug.Log(Time.time);
        transform.position = startPosition - Vector3.forward * newPosition;






    }
}
