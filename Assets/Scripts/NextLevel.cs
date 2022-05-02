using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int Scenes;

    // Start is called before the first frame update
    void Start()
    {
        Scenes = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Trigger (Collider Collider)
    {
        if (SceneManager.GetActiveScene().buildIndex==4)
        {

        }
        else
        {
            if (Collider.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(Scenes);
                if (Scenes > PlayerPrefs.GetInt("nextLevel"))
                {
                    PlayerPrefs.SetInt("nextLevel", Scenes);
                }
            }
        }
    }
   
}
