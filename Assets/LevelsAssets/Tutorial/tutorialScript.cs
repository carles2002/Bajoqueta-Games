using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public static bool camZoom = false;
    public float tiempoTutorial = 5f;
    public string tutorial = "";

    // Indicar si se ha presionado la tecla de espacio
    private bool spacePressed = false;

    void Start()
    {
        SetActiveAllChildren(false);
        // Comprueba si ya se ha ejecutado el tutorial antes
        if (PlayerPrefs.GetInt(tutorial, 0) == 0)
        {
            camZoom= false;
            SetActiveAllChildren(true);
            StartCoroutine(StartLevel());
        }
    }

    IEnumerator StartLevel()
    {
        float elapsedTime = 0;

        while (elapsedTime < tiempoTutorial && !spacePressed)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        camZoom = true;
        SetActiveAllChildren(false); // Desactivar todos los hijos
        PlayerPrefs.SetInt(tutorial, 1); // Marcar el tutorial como completado
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
    }
}
