using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movmentBlock : MonoBehaviour
{
    public GameObject player; // El objeto del jugador
    public Movement playerMovementScript; // El script de movimiento del jugador

    void OnTriggerEnter(Collider other)
    {
        // Si el objeto con el que colisionamos es el jugador...
        if (other.gameObject == player)
        {
            Debug.Log("SE HA DESACTIVADO");
            // ... desactiva su script de movimiento
           
            playerMovementScript.gameControl.ChangeGameRunningState(false);
        }
    }
}
