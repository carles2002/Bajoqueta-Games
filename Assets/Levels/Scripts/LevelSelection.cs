using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public static LevelSelection instancia;
    public Button[] lvlButtons;
    public int desbloquearNiveles;
    public int indicePrimerNivel = 1;

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
                lvlButtons[i].interactable = false;
            }
            for(int i=0; i < PlayerPrefs.GetInt("nivelesDesbloqueados", indicePrimerNivel); i++)
            {
                lvlButtons[i].interactable = true;
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
