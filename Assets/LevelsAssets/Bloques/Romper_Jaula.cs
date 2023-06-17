using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Romper_Jaula : MonoBehaviour
{
    //Variables para guardar la jaula normal y las piezas de jaula
    [SerializeField] GameObject Jaula_Entera;
    [SerializeField] GameObject Jaula_Pieza;
    [SerializeField] GameObject Cuby_Triste;
    [SerializeField] GameObject Cuby_Alegre;

    public int Veces_pulsado;

    //Sonido de Jaula
    public AudioSource QuienLoEmite;
    public AudioClip SonidoGrieta;
    public AudioClip SonidoRomper;



    // Start is called before the first frame update
    private void Awake()
    {
        //Activar la jaula normal y desactivar las piezas
        Jaula_Entera.SetActive(true);
        Jaula_Pieza.SetActive(false);
        Cuby_Triste.SetActive(true);
        Cuby_Alegre.SetActive(false);
    }
    void Start()
    {
        Veces_pulsado = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if(Veces_pulsado == 3) {
            Break();
      }
    }
    //activar la jaula normal y activar las piezas
    public void Break()
    {
        Jaula_Entera.SetActive(false);
        Jaula_Pieza.SetActive(true);
        Cuby_Triste.SetActive(false);
        Cuby_Alegre.SetActive(true);
    }
    public void Suma()
    {
        Veces_pulsado++;
    }
    public int cogerVeces()
    {
        return Veces_pulsado;
    }
    public void EmitirSonidoGrieta()
    {
        QuienLoEmite.PlayOneShot(SonidoGrieta);
    }
    public void EmitirSonidoRomper()
    {
        QuienLoEmite.PlayOneShot(SonidoRomper);
    }

}
