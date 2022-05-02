using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarMenu : MonoBehaviour
{
    // Funci�n que ejecutar� el cambio de escena al pulsar el bot�n
    public void MenuCreditos()
    {
        SceneManager.LoadScene("Credits");
    }
    public void MenuRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
    public void Menuprincipal()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void MenuLogros()
    {
        SceneManager.LoadScene("Logros");
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel_1");
    }
    public void MenuSeleccionFase()
    {
        SceneManager.LoadScene("SeleccionFase");
    }
}

/*https://www.youtube.com/watch?v=zGvM2pM0QzA */