using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float stability = 0.3f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void FixedUpdate()
    {
        
        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalMovement, 0.0f, 0.0f);
        rb.velocity = movement * speed;

        //http://answers.unity3d.com/questions/10425/how-to-stabilize-angular-motion-alignment-of-hover.html
        Vector3 predictedUp = Quaternion.AngleAxis(
         rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed, rb.angularVelocity ) * transform.up;
        //Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);

        if(gameObject.transform.rotation.x < 0.0f-0.1f && gameObject.transform.rotation.x > 0.0f + 0.1f) { 
        Vector3 torqueVectorUp = Vector3.Cross(predictedUp, Vector3.up);
        rb.AddTorque(torqueVectorUp * speed * speed);
        }
        else if(gameObject.transform.rotation.y < 0.0f - 0.1f && gameObject.transform.rotation.y > 0.0f + 0.1f)
        {
            Vector3 torqueVectorFront = Vector3.Cross(predictedUp, Vector3.forward);
            rb.AddTorque(torqueVectorFront * speed * speed);
        }

    }
}
