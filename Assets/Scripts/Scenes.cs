using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
            public void Escena (string nombreEscena)
        {
            SceneManager.LoadScene(nombreEscena);
        }
    
}
