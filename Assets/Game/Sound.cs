using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource QuienLoEmite;
    private AudioClip Sonido;
    public GameObject JukeBox;
    public float volumen = 5f;
//-----------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Quien lo emite: "+QuienLoEmite);
        Sonido = QuienLoEmite.clip;
        Debug.Log("Sonido: "+Sonido);
        EmitirSonido();
    }
//-----------------------------------------------------------------------------------------
    private void EmitirSonido(){
        AudioSource.PlayClipAtPoint(Sonido, JukeBox.transform.position);
    }
    
}
