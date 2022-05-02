using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScreenAnimation : MonoBehaviour
{
    float Target;
      

    //Función para crear el movimiento de fondo

    void Update()
    {
        Target += Time.deltaTime / 125;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), 0.05f);
       
    }
    
}

