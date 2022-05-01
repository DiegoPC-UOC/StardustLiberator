using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_EnemyBolt : MonoBehaviour 
{
    private GameController gameController;
    public GameObject explosion;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))return;

        Instantiate(explosion, transform.position, transform.rotation);
        
        Destroy(gameObject);
        
    }
}
