using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour
{
    public float speed = 30;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *=Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.up);
    }
}
