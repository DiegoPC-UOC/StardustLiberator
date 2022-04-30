using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float multiplicator;
    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {


        rig.angularVelocity = Random.insideUnitSphere * multiplicator;

    }

}
