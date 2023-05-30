using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    private bool gameRunning = true;
    
    
    private void SaveGame()
    {
        PlayerPrefs.SetInt("GameRunning", gameRunning ? 1 : 0);
        // Guarda aquí cualquier otra información del juego que necesites
        gameRunning= false;
    }

    private void LoadGame()
    {
        gameRunning = PlayerPrefs.GetInt("GameRunning", 0) == 1;
        // Carga aquí cualquier otra información del juego que necesites
        gameRunning = true;
    }

    public void ChangeGameRunningState(bool game)
    {
        gameRunning = game;
        
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
        
    }
}
