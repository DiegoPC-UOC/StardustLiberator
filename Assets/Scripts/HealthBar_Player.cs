using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Player : MonoBehaviour
{
    public Image BarraVida;
    public float vidaActual;
    public float vidaMaxima;
    private GameObject playerToFind;
    private DestroyByContact_Player destroyByContact_Player;

    void Awake()
    {
        playerToFind = GameObject.Find("PlayerShip");
        destroyByContact_Player = playerToFind.GetComponent<DestroyByContact_Player>();
        vidaMaxima = destroyByContact_Player.maxHealth;
    }
    void FixedUpdate()
    {
        vidaActual = destroyByContact_Player.actHealth;
        BarraVida.fillAmount = vidaActual / vidaMaxima;
    }
    public void DarVida(float vida)
    {
        vidaActual += vida;
    }
}