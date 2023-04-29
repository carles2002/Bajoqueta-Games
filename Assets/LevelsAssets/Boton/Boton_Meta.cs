using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_Meta : MonoBehaviour
{
    //Variables iniciales
    public GameObject[] lista;
    public float timer = 2;
    public bool puedeactivar = false;
    public Animator animator;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    timer = 2;
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
