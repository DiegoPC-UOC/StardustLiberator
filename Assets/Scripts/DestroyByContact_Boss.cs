using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_Boss : DestroyByContact
{
    
    // Se llama de nuevo al Start para que la barra de vida funcione y se destruya el objeto
    public override void Start()
    {
        actHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
       
    }
    public override void OnTriggerEnter(Collider other)
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