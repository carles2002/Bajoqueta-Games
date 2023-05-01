using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2 : MonoBehaviour
{
    public GameObject player; // Agrega una variable p�blica para el objeto "Player"
    public RuntimeAnimatorController newAnimatorController; // Agrega una variable p�blica para el nuevo AnimatorController
    public float yOffset = 2f; // Agrega una variable p�blica para la cantidad de unidades que el personaje se mover� hacia arriba
    public float platformYOffset = -1f; // Agrega una variable p�blica para la cantidad de unidades que la plataforma se mover� hacia abajo
    public Movement movimientoPlayer;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))

        {
            movimientoPlayer.gameControl.ChangeGameRunningState();
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Animator playerAnimator = player.GetComponent<Animator>(); // Obt�n el Animator del objeto "Player"

            Debug.Log("Entrado________________________");

            ChangeAnimatorController(playerAnimator);
            MovePlayerAboveObject(player.transform, yOffset);
            MovePlatformDown(transform, platformYOffset);

           
        }
    }

    private void ChangeAnimatorController(Animator animator)
    {
        if (newAnimatorController != null)
        {
            animator.runtimeAnimatorController = newAnimatorController;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un nuevo AnimatorController. Por favor, asigna uno en el Inspector.");
        }
    }

    private void MovePlayerAboveObject(Transform playerTransform, float yOffset)
    {
        Vector3 newPosition = transform.position;
        newPosition.y += yOffset;
        playerTransform.position = newPosition;
        playerTransform.rotation = Quaternion.Euler(0, 0, 0); // Establece la rotaci�n del jugador en (0, 0, 0)
    }


    private void MovePlatformDown(Transform platformTransform, float platformYOffset)
    {
        Vector3 newPosition = platformTransform.position;
        newPosition.y += platformYOffset;
        platformTransform.position = newPosition;
    }
}
