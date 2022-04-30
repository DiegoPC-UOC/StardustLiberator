using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpBar;
    public float hpActual;
    public float hpMax;
    
    public DestroyByContact_Boss destroyByContact_Boss;

    void Awake()
    {
        hpMax = destroyByContact_Boss.maxHealth;
    }
    void FixedUpdate()
    {
        hpActual = destroyByContact_Boss.actHealth;
        hpBar.fillAmount = hpActual / hpMax;
    }
}