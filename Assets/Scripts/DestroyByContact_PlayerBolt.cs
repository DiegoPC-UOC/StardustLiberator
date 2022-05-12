using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_PlayerBolt : MonoBehaviour 
{
    private GameController gameController;
    public GameObject explosion;
    private PlayerController playerController;
    private GameObject playerFind;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        playerFind = GameObject.Find("PlayerShip");
        playerController = playerFind.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player") || other.CompareTag("PowerUp")) return;
        if (playerController.haveShield == true) return;

        Instantiate(explosion, transform.position, transform.rotation);
        
        Destroy(gameObject);
        
    }
}
