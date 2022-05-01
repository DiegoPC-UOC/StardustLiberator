using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image BarraVida;
    public float vidaActual;
    public float vidaMaxima;

    void update()
    {
        BarraVida.fillAmount = vidaActual / vidaMaxima;
    }
}
