using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlMover : MonoBehaviour
{
    public GameObject levelCarousel;
    public GameObject levelZeroPosition; // La posición a la que se moverá el carrusel cuando esté en el nivel 0
    public GameObject levelFinalPosition; // La posición a la que se moverá el carrusel cuando esté en el nivel final
    public int currentLevel = 0;
    public float moveDistance = 10.0f; // La distancia que se moverá el carrusel de niveles
    public float moveTime = 1.0f; // El tiempo que tardará en moverse el carrusel de niveles
    public Text levelText; // El objeto de texto que muestra el nivel actual
    public int maxLevels = 3;
    public List<GameObject> objectsToDisable; // La lista de objetos que se desactivarán mientras el carrusel está en movimiento

    public AudioClip clip;
    private AudioSource audioSource;
    private void Start()
    {
        levelText.text = (currentLevel + 1).ToString();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource adjunto al objeto, lo agregamos.
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                audioSource.PlayOneShot(clip);
                if (hit.transform.name == "FI")
                {
                    // Mover al nivel anterior
                    StartCoroutine(MoveToPreviousLevel());
                }
                else if (hit.transform.name == "FD")
                {
                    // Mover al siguiente nivel
                    StartCoroutine(MoveToNextLevel());
                }
            }
        }
    }

    IEnumerator MoveToPreviousLevel()
    {
        // Desactiva los objetos
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        // Comprueba si ya estamos en el primer nivel
        if (currentLevel > 0)
        {
            Vector3 startPosition = levelCarousel.transform.position;
            Vector3 targetPosition = (currentLevel == 1) ? levelZeroPosition.transform.position : startPosition + Vector3.right * moveDistance;
            float elapsedTime = 0;

            while (elapsedTime < moveTime)
            {
                levelCarousel.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            levelCarousel.transform.position = targetPosition;
            if (currentLevel >= 1)
            {
                currentLevel--;
            }

            // Actualiza el texto del nivel
            levelText.text = (currentLevel + 1).ToString();
        }

        // Reactiva los objetos
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }
    }

    IEnumerator MoveToNextLevel()
    {
        // Desactiva los objetos
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        // Comprueba si ya estamos en el último nivel
        if (currentLevel < maxLevels - 1) // Cambiado para limitar a nivel 3
        {
            if (currentLevel < maxLevels - 1)
            {
                currentLevel++;
            }

            // Actualiza el texto del nivel
            levelText.text = (currentLevel + 1).ToString();

            Vector3 startPosition = levelCarousel.transform.position;
            Vector3 targetPosition = (currentLevel == 2) ? levelFinalPosition.transform.position : startPosition + Vector3.left * moveDistance; // Cambiado para limitar a nivel 3
            float elapsedTime = 0;

            while (elapsedTime < moveTime)
            {
                levelCarousel.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            levelCarousel.transform.position = targetPosition;

        }

        // Reactiva los objetos
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }
    }
}
