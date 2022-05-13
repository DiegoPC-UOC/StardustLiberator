using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_Player : DestroyByContact 
{
    private PlayerController playerController;
    private TimeControler timeControler;
    private GameObject canvasToFind;
    private GameObject playerToFind;
    public bool recuperarVida = false;


    public override void Start()
    {
        actHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        playerToFind = GameObject.Find("PlayerShip");
        playerController = playerToFind.GetComponent<PlayerController>();
        canvasToFind = GameObject.Find("Canvas");
        timeControler = canvasToFind.GetComponent<TimeControler>();
    }
    void Update()
    {
        if (recuperarVida == true)
        {
            actHealth = maxHealth;
        }

        if (!timeControler.GetenMarcha())
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
            StartCoroutine(Waiter());
            gameController.GameOver();
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player") || other.CompareTag("PowerUp")) return;
        if (playerController.haveShield == true) return;

        actHealth -= 1;
        Destroy(other.gameObject);

        if (actHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
            StartCoroutine(Waiter());
            gameController.GameOver();
        }
    }

    public void RecuperarVidaPowerUp()
    {
        recuperarVida = true;
        StartCoroutine(RecuperarVidaDownRoutine());
    }

    public IEnumerator RecuperarVidaDownRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        recuperarVida = false;
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5f);
    }
}