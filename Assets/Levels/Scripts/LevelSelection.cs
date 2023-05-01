using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int levelAt = PlayerPrefs.GetInt("levelAt", currentScene.buildIndex + 1); /* El numero es el último
                                                                                que tengas en Build Settings */

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

}
