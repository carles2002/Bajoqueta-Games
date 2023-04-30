using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private bool gameRunning;
    public string pauseSceneName = "PauseScene";

    private void SaveGame()
    {
        PlayerPrefs.SetInt("GameRunning", gameRunning ? 1 : 0);
        // Guarda aquí cualquier otra información del juego que necesites
    }

    private void LoadGame()
    {
        gameRunning = PlayerPrefs.GetInt("GameRunning", 0) == 1;
        // Carga aquí cualquier otra información del juego que necesites
    }

    public void ChangeGameRunningState()
    {
        gameRunning = !gameRunning;
        if (gameRunning)
        {
            //El juego está en curso --> Running
        }
        else
        {
            //El juego está pausado --> No Running
        }
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }

    private void Start()
    {
        LoadGame(); // Carga la información del juego al inicio
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveGame(); // Guarda la información del juego antes de cambiar de escena

            // Almacena el índice de la escena actual antes de cargar la escena de pausa
            PauseScript.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Cambia a la escena de pausa
            SceneManager.LoadScene(pauseSceneName);
        }
    }
}
