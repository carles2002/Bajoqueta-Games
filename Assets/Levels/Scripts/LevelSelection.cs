using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public static LevelSelection instancia;
    public GameObject[] lvlButtons;
    public GameObject[] lvlLocks;
    public int desbloquearNiveles;
    public int indicePrimerNivel = 2;

    private void Awake() {
        if( instancia == null)
        {
            instancia = this;
        }
    }

    void Start()
    {
        if(lvlButtons.Length > 0)
        {
            for(int i=0; i < lvlButtons.Length; i++)
            {
                lvlButtons[i].SetActive(false);
                lvlLocks[i].SetActive(true);
            }
            for(int i=0; i < PlayerPrefs.GetInt("nivelesDesbloqueados", indicePrimerNivel); i++)
            {
                lvlButtons[i].SetActive(true);
                lvlLocks[i].SetActive(false);
            }
        }
    }

    public void AumentarNiveles()
    {
        if(desbloquearNiveles > PlayerPrefs.GetInt("nivelesDesbloqueados", indicePrimerNivel))
        {
            PlayerPrefs.SetInt("nivelesDesbloqueados",desbloquearNiveles);
        }
    }

}
