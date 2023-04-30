using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_Meta : MonoBehaviour
{
    //Variables iniciales
    public GameObject[] lista;
    public float timer;
    public bool puedeactivar;
    public Animator animator;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.2f;
        i = 0;
        puedeactivar = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            timer -= Time.deltaTime;
            animator.SetBool("activado", true);
            if (timer < 0)
            {
                puedeactivar = true;
            }
            else
            {
                puedeactivar = false;
            }
            if (puedeactivar == true)
            {
                if (i <= 3)
                {
                    lista[i].SetActive(true);
                    i++;
                    timer = 0.5f;
                }
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("activado", false);
        }
    }
    
}
