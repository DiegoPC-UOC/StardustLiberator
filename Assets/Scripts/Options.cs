using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public RectTransform subMenu; //Parte del men� que se va a mover
    float posFinal;//Mover la x del submen�
    bool abrirMenu = true; //Saber si el men� est� abierto o cerrado
    public float tiempo = 0.5f; // Tiempo de ejecuci�n de la transici�n

    void Start()
    {
        posFinal = Screen.width / 2;//Para ocultar el subMenu. Se divide entre dos para que quede en el l�mite de la pantalla
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0); //Restar la posici�n final para que men� vaya a la izquierda
      }

    //Corrutina para mover el men� de opciones
    IEnumerator Mover (float time, Vector3 posInit, Vector3 posFin)//Se le pasa el tiempo, la posici�n inicial y la posici�n final
    {
        float elapsedTime = 0;
        while (elapsedTime < time)//elapsedTime para controlar el tiempo que se est� dentro del while
        {
            subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));/*si est� dentro de la pantalla se mover� hacia fuera y al rev�s
            y lo har� en el tiempo que se haya establecido, por eso se hace la divisi�n*/
            elapsedTime += Time.deltaTime;// Se ir� incrementando hasta llegar al tiempo deseado
            yield return null;
        }
        subMenu.position = posFin;
    }
    void MoverMenu (float time, Vector3 posInit, Vector3 posFin)//Men� que llama a la corrutina
    {
        StartCoroutine(Mover(time, posInit, posFin));
    }
    public void BUTTON_sub_Menu()//Se
    {//Se asigna un signo, y para que el men� vaya hacia la izquierda se le da un valor negativo
        int signo = 1;
        if (!abrirMenu)
            signo = -1;

        MoverMenu(tiempo, subMenu.position, new Vector3(signo * posFinal, subMenu.position.y, 0));/*Se le da la posici�n actual y se obtiene una
        nueva con la variable signo que indicar� si va hacia dentro o hacia fuera de la pantalla*/
        abrirMenu = !abrirMenu;
    }
}


/* https://www.youtube.com/watch?v=N4oQm_RGcGQ&list=PLrjSxxUlyA1r109VpEjcWeW5IgEcH2nne */