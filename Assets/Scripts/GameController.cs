using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //[Header("Scoreboard")]
    //public int score;
    //public Text scoreText;

    [Header("EnemySpawn")]
    public GameObject[] hazards;
    public GameObject finalBoss;
    public GameObject bossInstance;
    public GameObject canvasObject;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float bossScoreSpawn;

    [Header("PowerUpSpawn")] 
    public GameObject[] powerUps;
    public int powerUpsCount; 
    public float spawnWaitPW;
    public float startWaitPW;
    public float waveWaitPW;

    [Header("WindowMenu")]
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameCompleteMenu;

    Score sc;

    void Start()
    {
        sc = this.GetComponent<Score>();
        canvasObject.SetActive(false);
        //score.score = 0;
        //UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnWaves ()
    {
        
        yield return new WaitForSeconds(startWait);
        while (sc.score < bossScoreSpawn){
        
            for(int i=0; i<hazardCount; i++){

                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

        if (sc.score >= bossScoreSpawn)
        {
            Vector3 spawnPositionBoss = new Vector3(0, 0, 260);
            bossInstance = Instantiate(finalBoss, spawnPositionBoss, Quaternion.identity);
            canvasObject.SetActive(true);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(startWaitPW);
       
            while(true)
            {
                for (int i = 0; i < powerUpsCount; i++)
                {
                GameObject powerUp = powerUps[Random.Range(0, powerUps.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                //Instantiate(powerUp, spawnPosition, Quaternion.LookRotation()); 
                
                Instantiate(powerUp, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWaitPW);
                }
                yield return new WaitForSeconds(waveWaitPW);
            }
    }

    //public void AddScore(int value)
    //{
    //    score += value;
    //    UpdateScore();
    //}
    //void UpdateScore()
    //{
    //    scoreText.text = "Score: " + score;
    //}
    public void GameOver()
    {
        //Mostrar ventana
        gameOverMenu.SetActive(true);
        //Parar juego
        Time.timeScale = 0f;
    }
    public void GameComplete()
    {
        gameCompleteMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
}