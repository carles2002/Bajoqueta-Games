using QuickType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    private bool gameRunning = true;
    private int gemas = 0;
    private List<PolySkinElement> PolyDatabase;
    private string skinsJSON; 
    public GameObject polys;

    private void SaveGame()
    {
        PlayerPrefs.SetInt("GameRunning", gameRunning ? 1 : 0);
        PlayerPrefs.SetInt("Gems", gemas);
        PlayerPrefs.SetString("skinsJSON", skinsJSON);
        // Guarda aquí cualquier otra información del juego que necesites
        gameRunning = false;
    }

    private void LoadGame()
    {
        gameRunning = PlayerPrefs.GetInt("GameRunning", 0) == 1;
        gemas = PlayerPrefs.GetInt("Gems", 0);
        skinsJSON = PlayerPrefs.GetString("skinsJSON", "{\"polySkin\":[{\"skinID\":0,\"skinName\":\"Poly Enfadado\",\"skinDescription\":\"Poly ha tenido un mal dia, cuidado con el.\",\"skinPrice\":2,\"skinBuy\":0,\"skinSelected\":0},{\"skinID\":1,\"skinName\":\"Poly Alegre\",\"skinDescription\":\"Pon un Poly en tu vida\",\"skinPrice\":1,\"skinBuy\":1,\"skinSelected\":1},{\"skinID\":2,\"skinName\":\"Poly Caramelo\",\"skinDescription\":\"Yummy!\",\"skinPrice\":4,\"skinBuy\":0,\"skinSelected\":0},{\"skinID\":3,\"skinName\":\"Poly Sorprendido\",\"skinDescription\":\"Vaya, que habra visto?\",\"skinPrice\":3,\"skinBuy\":0,\"skinSelected\":0}]}");
        PolyDatabase = PolySkin.FromJson(skinsJSON).PolyDatabase;
       
        for (int i = 0; i < PolyDatabase.Count; i++)
        {
            if (PolyDatabase[i].SkinSelected == 1)
            {
                    switch (PolyDatabase[i].SkinId)
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
