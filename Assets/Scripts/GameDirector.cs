using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {

    public GUIText remainingDistanceText;
    public GUIText gameOverText;
    public GUIText speedText;
    public float distanceToGoal;
    public GameObject[] hazards;
    public float startWait;
    public float spawnWait;
    public Vector3 spawnValues;

    private int score;
    private bool gameOver = false;
    private bool restart = false;

    private float distanceAccumulated;
    private GameObject playerPhysics;
    private CustomPhysics customPhysics;


    // Use this for initialization
    void Start () {
        remainingDistanceText.text = "Distance Remaining: ";

        playerPhysics = GameObject.Find("Player Physics");
        if (playerPhysics)
            customPhysics = playerPhysics.GetComponent<CustomPhysics>();

        StartCoroutine(SpawnHarzards());
	}

    void FixedUpdate()
    {
        float cTODO_FIX_ME = 2.5f;
        float currentSpeed = customPhysics.Speed();

        distanceAccumulated += Time.deltaTime * currentSpeed;
        remainingDistanceText.text = "Distance Remaining: " + (distanceToGoal-distanceAccumulated);
        speedText.text = "Speed: " + (currentSpeed - cTODO_FIX_ME);
        if(distanceAccumulated >= distanceToGoal && !gameOver)
        {
            GameWon();
        }
        if (currentSpeed <= 0.01f && !gameOver)
        {
            OutOfSpeedGameOver();
        }
    }

    public void OutOfSpeedGameOver()
    {
        gameOver = true;
        gameOverText.text = "SPUN OUT";
    }

    public void GameWon()
    {
        gameOver = true;
        gameOverText.text = "YOU MADE IT!";
    }


    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "GAME OVER";
    }

    IEnumerator SpawnHarzards()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            GameObject hazard = hazards[Random.Range(0, hazards.Length)];

            Vector3 spawnValuesTemp = spawnValues;
            if (hazard.name == "Pot Hole" || hazard.name == "Work Cone") spawnValuesTemp.z = -spawnValues.z;

            spawnValuesTemp.y += hazard.transform.lossyScale.y / 2.0f;

            //Debug.Log(spawnValuesTemp.y);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesTemp.x, spawnValuesTemp.x), 
                                                spawnValuesTemp.y, 
                                                spawnValuesTemp.z);

            Instantiate(hazard, spawnPosition, Quaternion.identity);

            if (gameOver)
                break;

            yield return new WaitForSeconds(spawnWait);
        }

    }

}
