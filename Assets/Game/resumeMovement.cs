using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeMovement : MonoBehaviour
{
    private GameObject player; // El objeto del jugador
    private Movement playerMovementScript; // El script de movimiento del jugador

    private void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementScript = player.GetComponent<Movement>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el objeto con el que colisionamos es el jugador...
        if (other.gameObject == player)
        {
            Debug.Log("SE HA ACTIVADO");
            
            
            playerMovementScript.gameControl.ChangeGameRunningState(true);
        }
    }
}
