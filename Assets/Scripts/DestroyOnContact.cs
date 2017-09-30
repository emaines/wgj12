using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Boundary")
        //    return;

        //Instantiate(explosion, transform.position, transform.rotation);
        //if (other.tag == "Player")
        //{
        //    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        //    gameController.GameOver();
        //}

        //if (gameController)
        //    gameController.AddScore(pointsValue);

        //Destroy(other.gameObject);


        if (other.tag == "Fatal")
            Destroy(gameObject, 1);
    }




	// Update is called once per frame
	void Update () {
		
	}
}
