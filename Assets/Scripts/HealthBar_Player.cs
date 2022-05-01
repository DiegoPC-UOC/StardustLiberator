using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Player : MonoBehaviour
{
    public Image BarraVida;
    public float vidaActual;
    public float vidaMaxima;
    public DestroyByContact_Player destroyByContact_Player;
    void Awake()
    {
        vidaMaxima = destroyByContact_Player.maxHealth;
    }
    void FixedUpdate()
    {
        vidaActual = destroyByContact_Player.actHealth;
        BarraVida.fillAmount = vidaActual / vidaMaxima;
    }
}
