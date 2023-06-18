using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPlain : MonoBehaviour
{
    public Transform cube;
    public GameControl runningState;
    public ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            runningState.ChangeGameRunningState(true);
            Transform playerTransform = other.transform; // Obt�n el componente Transform del objeto "Player"
            playerTransform.position = cube.position;
            playerTransform.rotation = Quaternion.Euler(0, 0, 0); // Establece la rotaci�n del jugador en (0, 0, 0)

            // Inicia el efecto de part�culas
            particleSystem.Play();
        }
    }
}
