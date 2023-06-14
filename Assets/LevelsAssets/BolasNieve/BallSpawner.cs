using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // Referencia al prefab de la bola
    public float spawnRate = 3.0f; // Frecuencia de lanzamiento en segundos
    public float ballSpeed = 10.0f; // Velocidad de las bolas lanzadas
    public float detectionRadius = 7.0f; // Radio de detección del jugador
    public bool isActive = true; // Estado del spawner

    private Transform playerTransform; // Ubicación del jugador

    private void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Encuentra al jugador usando su etiqueta
    }
    private void Start()
    {
        StartCoroutine(SpawnBalls()); // Inicia la corrutina de lanzamiento de bolas

    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate); // Espera el tiempo definido

            // Si el jugador está dentro del radio de detección y el spawner está activo
            if (isActive && Vector3.Distance(playerTransform.position, transform.position) <= detectionRadius)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity); // Crea una nueva bola en la posición del spawner
                Rigidbody rb = ball.GetComponent<Rigidbody>(); // Obtiene el Rigidbody de la bola

                if (rb != null && playerTransform != null)
                {
                    Vector3 direction = (playerTransform.position - transform.position).normalized; // Calcula la dirección hacia el jugador
                    rb.velocity = direction * ballSpeed; // Aplica la velocidad a la bola
                }
            }
        }
    }
}
