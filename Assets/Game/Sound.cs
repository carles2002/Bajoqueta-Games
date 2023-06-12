using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource QuienLoEmite;
    public AudioClip Sonido;

    //-----------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { // Comprueba si el objeto colisionado tiene la etiqueta "Player"
            EmitirSonido();
        }
    }
    //-----------------------------------------------------------------------------------------
    private void EmitirSonido()
    {
        QuienLoEmite.PlayOneShot(Sonido);
    }
}
