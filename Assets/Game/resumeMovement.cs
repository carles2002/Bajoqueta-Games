using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeMovement : MonoBehaviour
{
    public GameObject player; // El objeto del jugador
    public Movement playerMovementScript; // El script de movimiento del jugador

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
