using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    private bool gameRunning = true;
    private int gemas = 0;
    private int skin = 0;
    public GameObject polys;

    private void SaveGame()
    {
        PlayerPrefs.SetInt("GameRunning", gameRunning ? 1 : 0);
        PlayerPrefs.SetInt("Gems", gemas);
        // Guarda aquí cualquier otra información del juego que necesites
        gameRunning = false;
    }

    private void LoadGame()
    {
        gameRunning = PlayerPrefs.GetInt("GameRunning", 0) == 1;
        gemas = PlayerPrefs.GetInt("Gems", 0);
        /*
        for (int i = 0; i < PolyDatabase.polysCount; i++)
        {
            if (PolyDatabase.GetPoly(i).SkinBuy)
            {
                    switch (PolyDatabase.GetPoly(i).SkinID)
                    {
                        case 0:
                            polys.transform.GetChild(0).gameObject.SetActive(true);
                            polys.transform.GetChild(1).gameObject.SetActive(false);
                            polys.transform.GetChild(2).gameObject.SetActive(false);
                            polys.transform.GetChild(3).gameObject.SetActive(false);
                            polys.transform.GetChild(0).parent = null;
                            break;
                        case 1:
                            polys.transform.GetChild(0).gameObject.SetActive(false);
                            polys.transform.GetChild(1).gameObject.SetActive(true);
                            polys.transform.GetChild(2).gameObject.SetActive(false);
                            polys.transform.GetChild(3).gameObject.SetActive(false);
                            polys.transform.GetChild(1).parent = null;
                            break;
                        case 2:
                            polys.transform.GetChild(0).gameObject.SetActive(false);
                            polys.transform.GetChild(1).gameObject.SetActive(false);
                            polys.transform.GetChild(2).gameObject.SetActive(true);
                            polys.transform.GetChild(3).gameObject.SetActive(false);
                            polys.transform.GetChild(2).parent = null;
                            break;
                        case 3:
                            polys.transform.GetChild(0).gameObject.SetActive(false);
                            polys.transform.GetChild(1).gameObject.SetActive(false);
                            polys.transform.GetChild(2).gameObject.SetActive(false);
                            polys.transform.GetChild(3).gameObject.SetActive(true);
                            polys.transform.GetChild(3).parent = null;
                            break;
                        default:
                            break;
                    }
            }
        }
        */
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
