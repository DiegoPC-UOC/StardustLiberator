using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Scoreboard")]
    public int score;

    [Header("EnemySpawn")]
    public GameObject[] hazards;
    public GameObject finalBoss;
    public GameObject canvasObject;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float bossScoreSpawn;

    void Start()
    {
        canvasObject.SetActive(false);
        score = 0;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves ()
    {
        
        yield return new WaitForSeconds(startWait);
        while (score < bossScoreSpawn){
        
            for(int i=0; i<hazardCount; i++){

                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

        if (score >= bossScoreSpawn)
        {
            Vector3 spawnPositionBoss = new Vector3(0, 0, 260);
            Instantiate(finalBoss, spawnPositionBoss, Quaternion.identity);
            canvasObject.SetActive(true);
        }
    }

    public void AddScore(int value)
    {
        score += value;
    }

}