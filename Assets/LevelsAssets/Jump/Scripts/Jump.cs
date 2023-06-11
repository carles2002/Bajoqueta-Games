using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour
{
    private GameObject player;
    public GameObject objectToMove;
    public float objectMoveDistance = 1f;
    public RuntimeAnimatorController newAnimatorController;
    private Movement movimientoPlayer;

    private bool isPlayerTouching = false;

    public GameObject detector;

    public float timeDetection = 1.5f;

    private void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movimientoPlayer= player.GetComponent<Movement>();
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("COLISION");
        StartCoroutine(activateDetector(timeDetection));
        // Verifica si el objeto en colisión es el Player
        if (collision.gameObject == player)
        {
            isPlayerTouching = true;
            Debug.Log(isPlayerTouching);

            // Guarda la rotación cuando el jugador entra en colisión
           
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Debug.Log("DES COLISION");
        detector.SetActive(false);
        // Verifica si el objeto que dejó de estar en colisión es el Player
        if (collision.gameObject == player)
        {
            isPlayerTouching = false;
            Debug.Log(isPlayerTouching);

            // Carga la rotación cuando el jugador deja de estar en colisión
            
        }
    }

    public bool IsPlayerTouching()
    {
        return isPlayerTouching;
    }

    public void PlayerDetected()
    {
        Debug.Log("MANDADO" + isPlayerTouching);
        if (isPlayerTouching)
        {
            movimientoPlayer.gameControl.ChangeGameRunningState(false);

            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            Animator playerAnimator = player.GetComponent<Animator>();

            Debug.Log("Entrado________________________");

            ChangeAnimatorController(playerAnimator);
            MoveObjectUp(objectToMove, objectMoveDistance);
        }
    }

    private void ChangeAnimatorController(Animator animator)
    {
        if (newAnimatorController != null)
        {
            SaveRotation();
            animator.runtimeAnimatorController = newAnimatorController;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un nuevo AnimatorController. Por favor, asigna uno en el Inspector.");
        }
    }

    private void MoveObjectUp(GameObject objectToMove, float moveDistance)
    {
        if (objectToMove != null)
        {
            objectToMove.transform.position += new Vector3(0, moveDistance, 0);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un objeto para mover. Por favor, asigna uno en el Inspector.");
        }
    }

    private void SaveRotation()
    {
        Quaternion rotation = player.transform.rotation;
        PlayerPrefs.SetFloat("PlayerRotationX", rotation.x);
        PlayerPrefs.SetFloat("PlayerRotationY", rotation.y);
        PlayerPrefs.SetFloat("PlayerRotationZ", rotation.z);
        PlayerPrefs.SetFloat("PlayerRotationW", rotation.w);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("PlayerRotationX").ToString());
    }

    private void LoadRotation()
    {
        float x = PlayerPrefs.GetFloat("PlayerRotationX");
        float y = PlayerPrefs.GetFloat("PlayerRotationY");
        float z = PlayerPrefs.GetFloat("PlayerRotationZ");
        float w = PlayerPrefs.GetFloat("PlayerRotationW");

        player.transform.rotation = new Quaternion(x, y, z, w);
    }
    
    IEnumerator activateDetector(float delay)
    {
        // Espera el número especificado de segundos
        yield return new WaitForSeconds(delay);

        // Después de la espera, invoca el evento
        detector.SetActive(true);
    }


}
