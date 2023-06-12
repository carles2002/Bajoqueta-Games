using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    // Ajusta el tiempo de vida de la bola para evitar problemas de rendimiento
    public float lifeTime = 3f;
    public float fX = 2f; // Fuerza que se aplicará en el eje X
    public float fY = 0f; // Fuerza que se aplicará en el eje Y
    public float fZ = 0f; // Fuerza que se aplicará en el eje Z

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
            Destroy(gameObject);
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>(); // Obtiene el Rigidbody del jugador
            if (playerRb != null) // Si el jugador tiene un Rigidbody
            {
                Vector3 force = new Vector3(fX, fY, fZ); // Fuerza que se aplicará
                Vector3 forcePosition = collision.contacts[0].point; // Obtiene el punto de contacto entre el jugador y la bola
                playerRb.AddForceAtPosition(force, forcePosition, ForceMode.Impulse); // Aplica la fuerza en el punto de contacto
            }
        }
    }
}
