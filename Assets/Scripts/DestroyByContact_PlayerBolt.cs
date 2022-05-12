using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_PlayerBolt : DestroyByContact_EnemyBolt 
{
    private PlayerController playerController;
    private GameObject playerFind;

    public override void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        playerFind = GameObject.Find("PlayerShip");
        playerController = playerFind.GetComponent<PlayerController>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player") || other.CompareTag("PowerUp")) return;
        if (playerController.haveShield == true && other.CompareTag("Player")) return;

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
