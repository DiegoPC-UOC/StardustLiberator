using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_EnemyBolt : MonoBehaviour 
{
    public GameObject explosion;
    [HideInInspector] public GameController gameController;
    public virtual void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUp")) return;

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
