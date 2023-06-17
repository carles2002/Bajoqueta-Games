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

    public AudioClip clip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource adjunto al objeto, lo agregamos.
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    IEnumerator PlayRandomWithDelay(float delay)
    {
        // Espera el número especificado de segundos
        yield return new WaitForSeconds(delay);
        
        audioSource.PlayOneShot(clip);
    }

    private void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movimientoPlayer= player.GetComponent<Movement>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!isPlayerTouching)
        {
            
            Debug.Log("COLISION");
            detector.SetActive(false);
            StartCoroutine(activateDetector(timeDetection));
            // Verifica si el objeto en colisión es el Player
            if (collision.gameObject == player)
            {
                isPlayerTouching = true;
                // Debug.Log(isPlayerTouching);

                // Guarda la rotación cuando el jugador entra en colisión

            }
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

            //Reproducir sonido
            StartCoroutine(PlayRandomWithDelay(0.3f));

            ChangeAnimatorController(playerAnimator);
            MoveObjectUp(objectToMove, objectMoveDistance);
            isPlayerTouching = false;
        }
    }

    private void ChangeAnimatorController(Animator animator)
    {
        if (newAnimatorController != null)
        {
            detector.SetActive(false);
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
        PlayerPrefs.SetInt("PlayerRotationX", Mathf.RoundToInt(rotation.x));
        PlayerPrefs.SetInt("PlayerRotationY", Mathf.RoundToInt(rotation.y));
        PlayerPrefs.SetInt("PlayerRotationZ", Mathf.RoundToInt(rotation.z));
        PlayerPrefs.SetInt("PlayerRotationW", Mathf.RoundToInt(rotation.w));
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetInt("PlayerRotationX").ToString());
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
