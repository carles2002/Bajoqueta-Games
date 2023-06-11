using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource QuienLoEmite;
    public AudioClip Sonido;


    //-----------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other) {
        EmitirSonido();
    }
    //-----------------------------------------------------------------------------------------
    private void EmitirSonido()
    {
        QuienLoEmite.PlayOneShot(Sonido);
    }



}
