using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource QuienLoEmite;
    public AudioClip Sonido;
    public float volumen = 1f;

    private void OnTriggerEnter(Collider other) {
        if(gameObject.tag.Equals("moneda")) StartCoroutine("EmitirSonidoYDestruir");
        else EmitirSonido();
    }

    private void EmitirSonido(){
        QuienLoEmite.PlayOneShot(Sonido, volumen);
    }
    IEnumerator EmitirSonidoYDestruir(){
        QuienLoEmite.PlayOneShot(Sonido, volumen);
        yield return new WaitForSeconds(Sonido.length); //Me espero a que termine para destruir el objeto
        Destroy(gameObject);
    }
}
