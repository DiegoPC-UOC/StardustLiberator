using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
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
        Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);        
    }
}
