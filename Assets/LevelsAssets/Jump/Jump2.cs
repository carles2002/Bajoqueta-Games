using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2 : MonoBehaviour
{
    public GameObject player; // Agrega una variable pública para el objeto "Player"
    public RuntimeAnimatorController newAnimatorController; // Agrega una variable pública para el nuevo AnimatorController
    public float yOffset = 2f; // Agrega una variable pública para la cantidad de unidades que el personaje se moverá hacia arriba
    public float platformYOffset = -1f; // Agrega una variable pública para la cantidad de unidades que la plataforma se moverá hacia abajo
    public Movement movimientoPlayer;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))

        {
            movimientoPlayer.gameControl.ChangeGameRunningState();
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Animator playerAnimator = player.GetComponent<Animator>(); // Obtén el Animator del objeto "Player"

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
        LoadRotation();
        Vector3 newPosition = transform.position;
        newPosition.y += yOffset;
        playerTransform.position = newPosition;

        // Obtiene la rotación actual
        Vector3 currentRotation = playerTransform.rotation.eulerAngles;

        // Corrige solo la posición z a 0, manteniendo las otras dos
        //playerTransform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
    }



    private void MovePlatformDown(Transform platformTransform, float platformYOffset)
    {
        Vector3 newPosition = platformTransform.position;
        newPosition.y += platformYOffset;
        platformTransform.position = newPosition;
    }
    private void LoadRotation()
    {
        float x = PlayerPrefs.GetFloat("PlayerRotationX");
        float y = PlayerPrefs.GetFloat("PlayerRotationY");
        float z = PlayerPrefs.GetFloat("PlayerRotationZ");
        float w = PlayerPrefs.GetFloat("PlayerRotationW");

        player.transform.rotation = new Quaternion(x, y, z, w);
    }
}
