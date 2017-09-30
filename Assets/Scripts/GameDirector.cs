using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {


    private int score;
    private bool gameOver = false;
    private bool restart = false;

    public GameObject[] hazards;
    //public int harzardCount;

    public float startWait;
    public float spawnWait;
    public Vector3 spawnValues;

    //public GUIText scoreText;
    //public GUIText gameOverText;
    //public GUIText restartText;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnHarzards());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnHarzards()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(- spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

            GameObject hazard = hazards[Random.Range(0, hazards.Length)];
            if (hazard.name == "Pot Hole") spawnValues.z = -spawnValues.z;


            Instantiate(hazards[Random.Range(0, hazards.Length)], spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);
        }

    }

}
