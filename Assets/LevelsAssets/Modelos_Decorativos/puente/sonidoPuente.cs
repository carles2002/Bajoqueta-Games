using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoPuente : MonoBehaviour
{
    public AudioClip[] clips;
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

    void OnCollisionEnter(Collision collision)
    {
        // Inicia una corutina que espera 1 segundo y luego reproduce el sonido
        StartCoroutine(PlayRandomWithDelay(1.0f));
    }

    IEnumerator PlayRandomWithDelay(float delay)
    {
        // Espera el número especificado de segundos
        yield return new WaitForSeconds(delay);

        // Selecciona un clip de audio aleatorio del array y lo reproduce
        AudioClip clip = clips[UnityEngine.Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(clip);
    }
}
