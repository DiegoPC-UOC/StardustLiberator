using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactPlayer : MonoBehaviour 
{

    public int scoreValue;
    public GameObject explosion;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player"))return;
    
        gameController.AddScore(scoreValue);
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
