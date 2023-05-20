using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Menu_Button : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public bool isStart = false;

    public GameObject objectToAnimate; // El objeto que quieres animar
    private Animator animator;

    // Asegúrate de que tu Trigger se llama "PolyJump" en tu Animator Controller
    private readonly string polyJumpTrigger = "PolyJump";

    private void Start()
    {
        // Recupera el componente Animator del objeto que quieres animar
        if (objectToAnimate != null)
        {
            animator = objectToAnimate.GetComponent<Animator>();
            
        }
        
    }

    private void OnMouseUpAsButton()
    {
        if (isStart)
        {
            if (animator != null)
            {
                Debug.Log("LLEGADO");
                animator.SetTrigger(polyJumpTrigger);
            }
           
        }

        // Inicia la corrutina para invocar el evento después de un retraso de 5 segundos
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
