using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    private Movement movimientoPlayer;
    private GameObject levelTransition;
    public Animator animator;

    void Start()
    {
        levelTransition = GameObject.FindGameObjectWithTag("levelTransition");
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

        movimientoPlayer = FindObjectOfType<Movement>();
        if(movimientoPlayer.gameControl.IsGameRunning() == false){movimientoPlayer.gameControl.ChangeGameRunningState(true);}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 8) /* El numero es el último
                                                                 que tengas en Build Settings */
            {
                //movimientoPlayer.gameControl.ChangeGameRunningState();
                Debug.Log("Has completado todos los niveles");

                //Mostrar pantalla de "Has ganado :D"
                animator.SetBool("pulsado", true);
                StartCoroutine("CargarVueltaAlMenu");
            }
            if (SceneManager.GetActiveScene().buildIndex == 7) /* cinematica */
            {
                SceneManager.LoadScene(8);
            }
            else
            {
                //Ir al siguiente nivel
               
                animator.SetBool("pulsado", true);

                StartCoroutine("CargarEscena");

                /*
                //Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
                */
            }
        }
    }
    /*Con esta función, cargaremos la siguiente escena y le damos tiempo
     a Poly de que termine de rotar antes de cargar*/
    IEnumerator CargarEscena(){

        movimientoPlayer.gameControl.ChangeGameRunningState(true);
        levelTransition.GetComponentInChildren<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1.2f);

        LevelSelection.instancia.AumentarNiveles();
        SceneManager.LoadScene(nextSceneLoad);
    }

    IEnumerator CargarVueltaAlMenu(){

        movimientoPlayer.gameControl.ChangeGameRunningState(true);
        levelTransition.GetComponentInChildren<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(1);
    }
}
