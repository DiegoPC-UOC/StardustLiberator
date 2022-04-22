using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact_Boss : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;
        if (other.tag == "Enemy") return;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
