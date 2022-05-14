using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarMenu : MonoBehaviour
{
    /// <summary>
    /// Variable que va a controlar si el juego se inicia de forma normal o no (Seleccion de fase).
    /// </summary>
    private int juegoNormal = 0;
    // Funcion que ejecutara el cambio de escena al pulsar el boton
    public void MenuCreditos()
    {
        SceneManager.LoadScene("Credits");
    }
    /// <summary>
    /// Muestra el menu de ranking
    /// </summary>
    public void MenuRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
    /// <summary>
    /// Muestra el menu principal
    /// </summary>
    public void Menuprincipal()
    {
        SceneManager.LoadScene("MainScreen");
    }
    /// <summary>
    /// Muestra el menu de logros
    /// </summary>
    public void MenuLogros()
    {
        SceneManager.LoadScene("Logros");
    }
    /// <summary>
    /// Carga la primera fase, indicando que es una partida normal
    /// </summary>
    public void Jugar()
    {
        juegoNormal = 1;
        PlayerPrefs.SetInt("juegoNormal", juegoNormal);
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("Nivel_1");
    }
    /// <summary>
    /// Muestra el menu de seleccion de fase
    /// </summary>
    public void MenuSeleccionFase()
    {
        SceneManager.LoadScene("SeleccionFase");
    }
}

/*https://www.youtube.com/watch?v=zGvM2pM0QzA */