using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public int scoreValue;
    public int maxHealth;
    [HideInInspector] public int actHealth;
    public GameObject explosion;
    [HideInInspector] public GameController gameController;
    [HideInInspector] public Score score;
    public virtual void Start()
    {
        actHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        score = gameControllerObject.GetComponent<Score>();

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUp")) return;

        actHealth -= 1;

        if (actHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            score.AddScore(scoreValue);
            Destroy(gameObject);
        }

    }
}