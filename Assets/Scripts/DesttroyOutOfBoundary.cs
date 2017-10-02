using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesttroyOutOfBoundary : MonoBehaviour {

    private GameObject gameObject;
    private GameDirector gameDirector;

    void Start()
    {
        gameObject = GameObject.Find("Game Manager");
        if (gameObject)
            gameDirector = gameObject.GetComponent<GameDirector>();
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
        else // Player
        {
            gameDirector.GameOver();
            Destroy(other.gameObject, 1.0f);
        }
    }
}
