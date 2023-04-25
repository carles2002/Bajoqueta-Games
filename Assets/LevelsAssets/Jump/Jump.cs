using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject player; // Agrega una variable p�blica para el objeto "Player"


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            Animator playerAnimator = player.GetComponent<Animator>(); // Obt�n el Animator del objeto "Player"

            Debug.Log("Entrado________________________");

        
                playerAnimator.SetTrigger("jump"); // Usa el Animator del objeto "Player"
            
        }
    }
}



