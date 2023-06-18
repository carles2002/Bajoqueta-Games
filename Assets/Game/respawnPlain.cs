using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPlain : MonoBehaviour
{
    public Transform cube;
    public GameControl runningState;
    public ParticleSystem particleSystem;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            runningState.ChangeGameRunningState(true);
            Transform playerTransform = other.transform; // Obtén el componente Transform del objeto "Player"
            playerTransform.position = cube.position;
            playerTransform.rotation = Quaternion.Euler(0, 0, 0); // Establece la rotación del jugador en (0, 0, 0)

            // Inicia el efecto de partículas
            particleSystem.Play();
            audioSource.PlayOneShot(clip);
        }
    }
}
