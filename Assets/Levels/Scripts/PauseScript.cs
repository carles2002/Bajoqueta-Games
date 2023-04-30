using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static int previousSceneIndex; // Almacena el índice de la escena anterior


    // Función para cargar la escena anterior
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}
