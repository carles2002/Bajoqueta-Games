using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static int previousSceneIndex; // Almacena el �ndice de la escena anterior


    // Funci�n para cargar la escena anterior
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}
