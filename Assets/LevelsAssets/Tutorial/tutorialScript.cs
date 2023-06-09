using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public static bool camZoom = false;

    void Start()
    {
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(5f);
        camZoom = true;
        gameObject.SetActive(false); // Desactivar este objeto
    }

    void Update()
    {

    }
}
