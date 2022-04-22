using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Scoreboard")]
    private int score;

    [Header("EnemySpawn")]
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    IEnumerator SpawnWaves ()
    {
        
        yield return new WaitForSeconds(startWait);
        while (true){
        
            for(int i=0; i<hazardCount; i++){

                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int value)
    {
        score += value;
    }

}
