using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltController_Boss : MonoBehaviour
{
    public GameObject shot;
    public Transform[] shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;
    public Transform shotSpawn5;
    public float fireRate;
    public float fireDelay;


    void Start()
    {
        InvokeRepeating("Fire", fireDelay, fireRate);
    }


    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);        
    }
}
