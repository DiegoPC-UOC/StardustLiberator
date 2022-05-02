using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{ //Función que ejecutará la salida del juego al pulsar el botón
    public void exit()
    {
        Application.Quit();
    }
}
