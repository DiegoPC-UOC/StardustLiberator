using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public RectTransform subMenu; //Parte del menú que se va a mover
    float posFinal;//Mover la x del submenú
    bool abrirMenu = true; //Saber si el menú está abierto o cerrado
    public float tiempo = 0.5f; // Tiempo de ejecución de la transición

    void Start()
    {
        posFinal = Screen.width / 2;//Para ocultar el subMenu. Se divide entre dos para que quede en el límite de la pantalla
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0); //Restar la posición final para que menú vaya a la izquierda
      }

    //Corrutina para mover el menú de opciones
    IEnumerator Mover (float time, Vector3 posInit, Vector3 posFin)//Se le pasa el tiempo, la posición inicial y la posición final
    {
        float elapsedTime = 0;
        while (elapsedTime < time)//elapsedTime para controlar el tiempo que se está dentro del while
        {
            subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));/*si está dentro de la pantalla se moverá hacia fuera y al revés
            y lo hará en el tiempo que se haya establecido, por eso se hace la división*/
            elapsedTime += Time.deltaTime;// Se irá incrementando hasta llegar al tiempo deseado
            yield return null;
        }
        subMenu.position = posFin;
    }
    void MoverMenu (float time, Vector3 posInit, Vector3 posFin)//Menú que llama a la corrutina
    {
        StartCoroutine(Mover(time, posInit, posFin));
    }
    public void BUTTON_sub_Menu()//Se
    {//Se asigna un signo, y para que el menú vaya hacia la izquierda se le da un valor negativo
        int signo = 1;
        if (!abrirMenu)
            signo = -1;

        MoverMenu(tiempo, subMenu.position, new Vector3(signo * posFinal, subMenu.position.y, 0));/*Se le da la posición actual y se obtiene una
        nueva con la variable signo que indicará si va hacia dentro o hacia fuera de la pantalla*/
        abrirMenu = !abrirMenu;
    }
}


/* https://www.youtube.com/watch?v=N4oQm_RGcGQ&list=PLrjSxxUlyA1r109VpEjcWeW5IgEcH2nne */