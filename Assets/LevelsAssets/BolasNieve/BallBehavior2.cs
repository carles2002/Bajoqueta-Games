using System.Collections;
using UnityEngine;

public class BallBehavior2 : MonoBehaviour
{
    // Ajusta el tiempo de vida de la bola para evitar problemas de rendimiento
    public float lifeTime = 3f;
    public float moveDuration = 0.5f; // Duración del movimiento
    public float moveDistance = 1f; // Distancia de desplazamiento en el eje X

    // Inicializar
    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruye la bola después de cierto tiempo para limpiar la escena
    }

    void OnCollisionEnter(Collision collision) // Este método se llama cuando la bola entra en contacto con otro objeto
    {
        if (collision.gameObject.CompareTag("Player")) // Si el objeto con el que se ha chocado es el jugador
        {
            // Ejecuta la acción adicional aquí
            Debug.Log("La bola ha golpeado al jugador!");
            Destroy(gameObject); // Destruye la bola

            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null) // Si el jugador tiene un Rigidbody
            {
                StartCoroutine(MovePlayer(collision.gameObject.transform, playerRb)); // Comienza la corrutina para mover al jugador
            }
        }
    }

    IEnumerator MovePlayer(Transform playerTransform, Rigidbody playerRb)
    {
        playerRb.isKinematic = true; // Desactiva la física del jugador

        Vector3 startPosition = playerTransform.position; // Posición inicial del jugador
        Vector3 endPosition = startPosition + new Vector3(moveDistance, 0, 0); // Posición final del jugador

        float elapsedTime = 0; // Tiempo transcurrido desde el inicio del movimiento
        Vector3 currentVelocity = Vector3.zero; // Velocidad actual para SmoothDamp

        while (elapsedTime < moveDuration)
        {
            playerTransform.position = Vector3.SmoothDamp(playerTransform.position, endPosition, ref currentVelocity, moveDuration); // Mueve al jugador
            elapsedTime += Time.deltaTime; // Incrementa el tiempo transcurrido
            yield return null;
        }

        playerRb.isKinematic = false; // Reactiva la física del jugador
    }
}
