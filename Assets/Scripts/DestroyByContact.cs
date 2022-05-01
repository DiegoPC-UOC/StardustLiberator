using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{

    public int scoreValue;
    public int maxHealth;
    public int actHealth;
    public GameObject explosion;
    private GameController gameController;

    void Start()
    {
        actHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))return;
        
        actHealth -= 1;

        if (actHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
        
    }
}
