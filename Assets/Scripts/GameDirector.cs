using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour {

    public bool debugBoost = true;
    public int debugSpawnIndex = 0;
    public GUIText remainingDistanceText;
    public GUIText gameOverText;
    public GUIText speedText;
    public GUIText restartMessage;
    public GUIText scoreText;
    public float distanceToGoal;
    public GameObject[] hazards;
    public float startWait;
    public float spawnWait;
    public Vector3 spawnValues;

    public AudioSource[] gameMusic;
    public AudioSource startingMusic;
    public AudioSource retryMusic;

    private int score;
    private bool gameOver = false;

    private float distanceAccumulated;
    private GameObject playerPhysics;
    private CustomPhysics customPhysics;


    // Use this for initialization
    void Start () {
        remainingDistanceText.text = "Distance Remaining: ";
        speedText.text = "Speed:";
        gameOverText.text = "";
        restartMessage.text = "";
        scoreText.text = "";


        playerPhysics = GameObject.Find("Player Physics");
        if (playerPhysics)
            customPhysics = playerPhysics.GetComponent<CustomPhysics>();
        else
            Debug.LogError(playerPhysics + "Not found");

        gameMusic = GetComponents<AudioSource>();
        startingMusic = gameMusic[0];
        retryMusic= gameMusic[1];

        startingMusic.Play();

        StartCoroutine(SpawnHarzards());
	}

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetButton("Fire1"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = customPhysics.Speed();

        distanceAccumulated += Time.deltaTime * currentSpeed;
        remainingDistanceText.text = "Distance Remaining: " + (int) (distanceToGoal-distanceAccumulated);
        speedText.text = "Speed: " + (int) currentSpeed;
        if(distanceAccumulated >= distanceToGoal && !gameOver)
        {
            GameWon();
        }
        if (currentSpeed <= 0.01f && !gameOver)
        {
            OutOfSpeedGameOver();
        }
        scoreText.text = score.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
    }

    public void OutOfSpeedGameOver()
    {
        gameOver = true;
        gameOverText.text = "SPUN OUT";
        restartMessage.text = "Press fire to restart";
        startingMusic.Stop();
        retryMusic.Play();
    }

    public void GameWon()
    {
        gameOver = true;
        gameOverText.text = "YOU MADE IT!";
    }


    public void GameOver()
    {
        if (!gameOver) { 
            gameOver = true;
            gameOverText.text = "GAME OVER";
            restartMessage.text = "Press fire to restart";
            startingMusic.Stop();
            retryMusic.Play();
        }
    }

    IEnumerator SpawnHarzards()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            GameObject hazard;
            if (!debugBoost)
            {
                hazard = hazards[Random.Range(0, hazards.Length)];
            }
            else
            {
                hazard = hazards[debugSpawnIndex];
            }

            Vector3 spawnValuesTemp = spawnValues;
            if (hazard.name == "Pot Hole" || hazard.name == "Work Cone") spawnValuesTemp.z = -spawnValues.z;

            if(hazard.name != "Work Cone")
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
