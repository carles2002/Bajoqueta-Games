using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Menu_Button : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public bool isStart = false;

    public GameObject PolyAnimate;
    public GameObject ButtonAnimate;
    private Animator animator;
   

    // Asegúrate de que tu Trigger se llama "PolyJump" en tu Animator Controller
    private readonly string polyJumpTrigger = "PolyJump";


    public AudioClip clip;
    private AudioSource audioSource;

    private void Start()
    {
        // Recupera el componente Animator del objeto que quieres animar
        if (PolyAnimate != null)
        {
            animator = PolyAnimate.GetComponent<Animator>();
            
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource adjunto al objeto, lo agregamos.
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        

    }

    private void OnMouseUpAsButton()
    {
        if (isStart)
        {
            if (animator != null)
            {
                Debug.Log("LLEGADO");
                animator.SetTrigger(polyJumpTrigger);
                audioSource.PlayOneShot(clip);
            }
           
        }

        // Inicia la corrutina para invocar el evento después de un retraso de 1 segundos
        StartCoroutine(InvokeEventAfterDelay(1.0f));
    }

    IEnumerator InvokeEventAfterDelay(float delay)
    {
        // Espera el número especificado de segundos
        yield return new WaitForSeconds(delay);

        // Después de la espera, invoca el evento
        unityEvent.Invoke();
    }


}
