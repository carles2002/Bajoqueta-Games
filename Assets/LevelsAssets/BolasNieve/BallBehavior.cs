using System.Collections;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    // Ajusta el tiempo de vida de la bola para evitar problemas de rendimiento
    public float lifeTime = 3f;
    public float forceDuration = 0.5f; // Duraci�n de la aplicaci�n de la fuerza
    public float forceStrength = 2f; // Fuerza que se aplicar� en el eje X

    // Inicializar
    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruye la bola despu�s de cierto tiempo para limpiar la escena
    }

    void OnCollisionEnter(Collision collision) // Este m�todo se llama cuando la bola entra en contacto con otro objeto
    {
        if (collision.gameObject.CompareTag("Player")) // Si el objeto con el que se ha chocado es el jugador
        {
            // Ejecuta la acci�n adicional aqu�
            Debug.Log("La bola ha golpeado al jugador!");
            Destroy(gameObject);
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>(); // Obtiene el Rigidbody del jugador
            if (playerRb != null) // Si el jugador tiene un Rigidbody
            {
                StartCoroutine(ApplyForceToPlayer(playerRb)); // Comienza la corrutina para aplicar fuerza al jugador
            }
        }

        //Destroy(gameObject); // Destruye la bola
    }

    IEnumerator ApplyForceToPlayer(Rigidbody playerRb)
    {
        float elapsedTime = 0; // Tiempo transcurrido desde el inicio de la aplicaci�n de la fuerza

        while (elapsedTime < forceDuration)
        {
            Vector3 force = new Vector3(forceStrength, 0, 0); // Fuerza que se aplicar�
            playerRb.AddForce(force, ForceMode.Impulse); // Aplica la fuerza al Rigidbody del jugador

            elapsedTime += Time.fixedDeltaTime; // Incrementa el tiempo transcurrido
            yield return new WaitForFixedUpdate(); // Espera hasta la pr�xima actualizaci�n de f�sica
        }
    }
}
