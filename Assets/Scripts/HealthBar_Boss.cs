using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Boss : MonoBehaviour
{
    public Image hpBar;
    public float hpActual;
    public float hpMax;
    public GameObject bossToFind;
    public DestroyByContact_Boss destroyByContact_Boss;
    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }
    void FixedUpdate()
    {
        if (gameController.bossInstance != null) 
        {
        
            bossToFind = gameController.bossInstance;
            destroyByContact_Boss = bossToFind.GetComponent<DestroyByContact_Boss>();

            hpMax = destroyByContact_Boss.maxHealth;
            hpActual = destroyByContact_Boss.actHealth;

            if (hpActual == 1)
            {
                hpActual = 0;
            }

            hpBar.fillAmount = hpActual / hpMax;
        }
    }
}