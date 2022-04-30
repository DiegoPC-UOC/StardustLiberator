using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_Boss : MonoBehaviour
{

    public int scoreValue;
    public int maxHealth;
    public int actHealth;
    private GameController gameController;
    public GameObject explosion;
    public GameObject playerExplosion;

    void Start()
    {
        actHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        actHealth -= 1;
        Destroy(other.gameObject);
        
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
        }

        if (actHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
