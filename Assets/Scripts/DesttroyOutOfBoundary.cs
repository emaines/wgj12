using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesttroyOutOfBoundary : MonoBehaviour {

    private GameObject directorGameObject;
    private GameDirector gameDirector;

    void Start()
    {
        directorGameObject = GameObject.Find("Game Manager");
        if (directorGameObject)
            gameDirector = directorGameObject.GetComponent<GameDirector>();
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
