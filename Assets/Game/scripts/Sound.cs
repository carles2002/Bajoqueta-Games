using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource QuienLoEmite;
    public AudioClip Sonido;
    public float segRetardo;

    private void Start() {
        if(segRetardo<=0) segRetardo = 1f;
    }

    //-----------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { // Comprueba si el objeto colisionado tiene la etiqueta "Player"
            EmitirSonido(QuienLoEmite, Sonido);
        }
    }
    //-----------------------------------------------------------------------------------------
    public void EmitirSonido(AudioSource QuienLoEmite, AudioClip Sonido)
    {
        QuienLoEmite.PlayOneShot(Sonido);
    }
    public IEnumerator EmitirSonidoConRetardo(AudioSource QuienLoEmite, AudioClip Sonido, float Segundos)
    {
        yield return new WaitForSeconds(Segundos);
        QuienLoEmite.PlayOneShot(Sonido);
    }
}
