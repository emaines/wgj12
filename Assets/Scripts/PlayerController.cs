using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float stability = 0.3f;
    public float tilt = 0.1f;
    private Rigidbody rb;

    private GameObject playerPhysics;
    private CustomPhysics customPhysics;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        playerPhysics = GameObject.Find("Player Physics");
        if (playerPhysics)
            customPhysics = playerPhysics.GetComponent<CustomPhysics>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void FixedUpdate()
    {
        float playerSpeed = customPhysics.Speed();
        float relativeSpeed = customPhysics.Speed() / customPhysics.MaxSpeed() + 0.5f;

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement * relativeSpeed, 0.0f, verticalMovement * relativeSpeed);
        if(playerSpeed > 0.01f)
        {
            movement = movement * speed;
            movement.y = rb.velocity.y; // preserve vertical velocity for jumps
            rb.velocity = movement;
        }

        //http://answers.unity3d.com/questions/10425/how-to-stabilize-angular-motion-alignment-of-hover.html
        Vector3 predictedUp = Quaternion.AngleAxis(
        rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed, rb.angularVelocity ) * transform.up;
        Vector3 torqueVectorUp = Vector3.Cross(predictedUp, Vector3.up);
        //Vector3 torqueVectorForward = Vector3.Cross(predictedUp, Vector3.forward);
        rb.AddTorque(torqueVectorUp * speed * speed);
        //rb.AddTorque(torqueVectorForward * speed * speed);

        rb.rotation = Quaternion.Euler(0.0f, 90.0f, (rb.velocity.x * -tilt));
    }
}
