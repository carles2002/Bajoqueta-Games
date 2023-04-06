using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayerPrefs : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            //Borramos todo y habilitamos solo el 1
            PlayerPrefs.DeleteAll();
            PlayerPrefs.GetInt("levelAt", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
