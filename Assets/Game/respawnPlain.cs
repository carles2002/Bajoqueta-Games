using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPlain : MonoBehaviour
{
    public Transform cube;
    public Movement playerMovementScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovementScript.gameControl.ChangeGameRunningState(true);
            Transform playerTransform = other.transform; // Obtén el componente Transform del objeto "Player"
            playerTransform.position = cube.position;
            playerTransform.rotation = Quaternion.Euler(0, 0, 0); // Establece la rotación del jugador en (0, 0, 0)
            
        }
    }
}
