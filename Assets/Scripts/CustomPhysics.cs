using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour {

    private float playerSpeed = 5.0f;
    public float decelaration = 0.01f;


    public void BoostSpeed(float speed)
    {
        playerSpeed += speed;
    }

    public float Speed()
    {
        return playerSpeed;
    }
    
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void FixedUpdate()
    {
        if(playerSpeed > 0.001f)
            playerSpeed -= Time.deltaTime * decelaration;
    }

}
