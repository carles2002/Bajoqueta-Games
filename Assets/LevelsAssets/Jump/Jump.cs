using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToMove;
    public float objectMoveDistance = 1f;
    public RuntimeAnimatorController newAnimatorController;
    public Movement movimientoPlayer;

    public bool isPlayerTouching = false;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("COLISION");
        // Verifica si el objeto en colisión es el Player
        if (collision.gameObject == player)
        {
            isPlayerTouching = true;
            Debug.Log(isPlayerTouching);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Debug.Log("DES COLISION");
        // Verifica si el objeto que dejó de estar en colisión es el Player
        if (collision.gameObject == player)
        {
            isPlayerTouching = false;
            Debug.Log(isPlayerTouching);
        }
    }

    public bool IsPlayerTouching()
    {
        return isPlayerTouching;
    }

    public void PlayerDetected()
    {
        Debug.Log("MANDADO"+ isPlayerTouching);
        if (isPlayerTouching)
        {
            movimientoPlayer.gameControl.ChangeGameRunningState();

            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            Animator playerAnimator = player.GetComponent<Animator>();

            Debug.Log("Entrado________________________");

            ChangeAnimatorController(playerAnimator);
            MoveObjectUp(objectToMove, objectMoveDistance);
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
