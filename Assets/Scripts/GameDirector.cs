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

            GameObject hazard = hazards[Random.Range(0, hazards.Length)];
            //GameObject hazard = hazards[1];

            Vector3 spawnValuesTemp = spawnValues;
            if (hazard.name == "Pot Hole") spawnValuesTemp.z = -spawnValues.z;

            spawnValuesTemp.y += hazard.transform.lossyScale.y / 2.0f;

            //Debug.Log(spawnValuesTemp.y);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesTemp.x, spawnValuesTemp.x), 
                                                spawnValuesTemp.y, 
                                                spawnValuesTemp.z);

            Instantiate(hazard, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);
        }

    }

}
