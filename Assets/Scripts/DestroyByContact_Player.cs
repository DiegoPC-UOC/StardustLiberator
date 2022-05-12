using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_Player : MonoBehaviour 
{

    public int scoreValue;
    public int maxHealth;
    public int actHealth;
    public GameObject explosion;
    private GameController gameController;
    private PlayerController playerController;
    private GameObject playerFind;
    //Nuevo
    public bool recuperarVida = false;


    void Start()
    {
        actHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        playerFind = GameObject.Find("PlayerShip");
        playerController = playerFind.GetComponent<PlayerController>();
    }

    //Nuevo

    void Update()
    {
        //Aqui meter que recupere vida
        if (recuperarVida == true)
        {
            actHealth = maxHealth;
        }

    }

    void OnTriggerEnter(Collider other)
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
            gameController.GameOver();
        }
    }

   //Nuevo

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
}
