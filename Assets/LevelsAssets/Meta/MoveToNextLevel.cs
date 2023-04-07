using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    private Movement movimientoPlayer;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

        movimientoPlayer = FindObjectOfType<Movement>();
        if(movimientoPlayer.gameControl.IsGameRunning() == false){movimientoPlayer.gameControl.ChangeGameRunningState();}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 4) /* El numero es el último
                                                                 que tengas en Build Settings */
            {
                movimientoPlayer.gameControl.ChangeGameRunningState();
                Debug.Log("Has completado todos los niveles");

                //Mostrar pantalla de "Has ganado :D"

                StartCoroutine("CargarVueltaAlMenu");
            }
            else
            {
                //Ir al siguiente nivel
                
                StartCoroutine("CargarEscena");

                //Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
    /*Con esta función, cargaremos la siguiente escena y le damos tiempo
     a Poly de que termine de rotar antes de cargar*/
    IEnumerator CargarEscena(){

        movimientoPlayer.gameControl.ChangeGameRunningState();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneLoad);
    }

    IEnumerator CargarVueltaAlMenu(){

        movimientoPlayer.gameControl.ChangeGameRunningState();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
