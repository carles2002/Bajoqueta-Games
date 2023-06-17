using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casilla_salto : MonoBehaviour
{
    public Animator animator;
    public Sound sonido;
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("casilla_jump",true);
        }
    }
    */
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            animator.SetBool("casilla_jump",true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            sonido.EmitirSonidoConRetardo(sonido.QuienLoEmite,sonido.Sonido, sonido.segRetardo);
            animator.SetBool("casilla_jump", false);
        }
    }
}
