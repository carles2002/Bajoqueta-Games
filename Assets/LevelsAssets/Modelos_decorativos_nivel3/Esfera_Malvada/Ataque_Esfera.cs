using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Esfera : MonoBehaviour
{
    public GameObject bola;
    public Animator animator;
    public float time;
   
    // Start is called before the first frame update
    void Start()
    {
        time = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        bola = GameObject.FindGameObjectWithTag("bola");
        if (bola!=null)
        {
            time = 0.1f;
            Ataque();
            time -= Time.deltaTime;
            if (time < 0)
            {
                Normal();
                time = 0.1f;
            }
        }
        else
        {
            Normal();
        }
    }
    private void Ataque()
    {
        animator.SetBool("attack", true);        
    }
    private void Normal()
    {
        animator.SetBool("attack", false);
        
    }
    
}
