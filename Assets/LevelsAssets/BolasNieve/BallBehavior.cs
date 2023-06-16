using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour
{
    // Ajusta el tiempo de vida de la bola para evitar problemas de rendimiento
    public float lifeTime = 3f;
    public float fX = 2f; // Fuerza que se aplicar� en el eje X
    public float fY = 0f; // Fuerza que se aplicar� en el eje Y
    public float fZ = 0f; // Fuerza que se aplicar� en el eje Z

    private GameObject player; // El objeto del jugador
    private Movement playerMovementScript; // El script de movimiento del jugador

    public Sound sonido;
    private AudioSource audioSource;
    private AudioClip audioClip;


    // Inicializar
    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruye la bola despu�s de cierto tiempo para limpiar la escena
        audioSource = sonido.GetComponent<AudioSource>();
        audioClip = sonido.Sonido;

    }

    private void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementScript = player.GetComponent<Movement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("La bola ha golpeado al jugador!");

            // Selecciona un clip de audio aleatorio del array y lo reproduce
            //AudioClip clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            sonido.EmitirSonido(audioSource,audioClip);

            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 force = new Vector3(fX, fY, fZ);
                Vector3 forcePosition = collision.contacts[0].point;
                playerRb.AddForceAtPosition(force, forcePosition, ForceMode.Impulse);

                playerMovementScript.gameControl.ChangeGameRunningState(false);

                // Inicia una Coroutine para reanudar el movimiento del jugador despu�s de 1 segundo
                StartCoroutine(ResumePlayerMovementAfterDelay(0.1f));
            }
        }
    }

    IEnumerator ResumePlayerMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerMovementScript.gameControl.ChangeGameRunningState(true);
        Debug.Log("Desbloqueado");
        Destroy(gameObject);
    }
}
