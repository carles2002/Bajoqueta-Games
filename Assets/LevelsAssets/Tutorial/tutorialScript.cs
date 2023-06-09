using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public static bool camZoom = false;

    void Start()
    {
        SetActiveAllChildren(false);
        // Comprueba si ya se ha ejecutado el tutorial antes
        if (PlayerPrefs.GetInt("TutorialCompleted1", 0) == 0)
        {
            SetActiveAllChildren(true);
            StartCoroutine(StartLevel());
        }
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(5f);
        camZoom = true;
        SetActiveAllChildren(false); // Desactivar todos los hijos
        PlayerPrefs.SetInt("TutorialCompleted1", 1); // Marcar el tutorial como completado
    }

    void SetActiveAllChildren(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }

    void Update()
    {

    }
}
