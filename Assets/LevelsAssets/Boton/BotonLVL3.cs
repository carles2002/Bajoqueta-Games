using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonLVL3 : MonoBehaviour
{
    //Variables iniciales
    public  Romper_Jaula Rj; //Encontrar el script de Romper_Jaula

    public Animator animator;

    public AudioSource QuienLoEmite;
    public AudioClip SonidoBoton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player")) {
            if (gameObject.name=="boton_camino_1")
            {
                animator.SetBool("pressed", true);
                EmitirSonido();
                Rj.Suma();
                int veces = Rj.cogerVeces();
                if (veces==1)
                {
                    Rj.EmitirSonidoGrieta();
                }
                if (veces == 2)
                {
                    Rj.EmitirSonidoGrieta();
                }
                if (veces == 3)
                {
                    Rj.EmitirSonidoRomper();
                }


            }
        }

    }
    private void EmitirSonido()
    {
        QuienLoEmite.PlayOneShot(SonidoBoton);
    }



}
