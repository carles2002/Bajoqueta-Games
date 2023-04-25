using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject player; // Agrega una variable p�blica para el objeto "Player"
    public GameObject objectToMove; // Agrega una variable p�blica para el objeto que quieres mover
    public float objectMoveDistance = 1f; // Agrega una variable p�blica para la distancia que se mover� el objeto
    public RuntimeAnimatorController newAnimatorController; // Agrega una variable p�blica para el nuevo AnimatorController

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Animator playerAnimator = player.GetComponent<Animator>(); // Obt�n el Animator del objeto "Player"

            Debug.Log("Entrado________________________");

            ChangeAnimatorController(playerAnimator);
            MoveObjectUp(objectToMove, objectMoveDistance);

            // playerAnimator.SetTrigger("jump"); // Usa el Animator del objeto "Player"
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

    private void MoveObjectUp(GameObject objectToMove, float moveDistance)
    {
        if (objectToMove != null)
        {
            objectToMove.transform.position += new Vector3(0, moveDistance, 0);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un objeto para mover. Por favor, asigna uno en el Inspector.");
        }
    }
}
