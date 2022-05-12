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

    void Start()
    {
        actHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUp"))return;

        actHealth -= 1;

        if (actHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            gameController.GameComplete();
            Destroy(gameObject);
        }
    }
}
