using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public Button[] levelButtons;
    private void Start()
    {
        int levelScene = PlayerPrefs.GetInt("nextLevel", 1);

        for (int i=0; i < levelButtons.Length; i++)
        {
            if(i+1> levelScene)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

}
