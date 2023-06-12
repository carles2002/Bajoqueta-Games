using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class metaLVL3 : MonoBehaviour
{
    public List<GameObject> objectsToCheck; // Lista de GameObjects a comprobar

    private BallSpawner ballSpawner;

    private Movement playerMovementScript; // El script de movimiento del jugador
    private GameObject player; // El objeto del jugador

    private void Start()
    {
        // Verificar si la lista tiene exactamente 0 objetos
        
            ballSpawner = GameObject.FindObjectOfType<BallSpawner>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementScript = player.GetComponent<Movement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && ballSpawner != null)
        {
            if (objectsToCheck.Count == 0)
            {
                ballSpawner.isActive = false;
                playerMovementScript.gameControl.ChangeGameRunningState(false);
            }
        }
    }
}
