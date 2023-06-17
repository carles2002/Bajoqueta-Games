using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlMover : MonoBehaviour
{
    public GameObject levelCarousel;
    public GameObject levelZeroPosition; // La posición a la que se moverá el carrusel cuando esté en el nivel 0
    public int currentLevel = 0;
    public float moveDistance = 10.0f; // La distancia que se moverá el carrusel de niveles
    public float moveTime = 1.0f; // El tiempo que tardará en moverse el carrusel de niveles

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
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
            currentLevel--;
        }
    }

    IEnumerator MoveToNextLevel()
    {
        // Comprueba si ya estamos en el último nivel
        if (currentLevel < levelCarousel.transform.childCount - 1)
        {
            Vector3 startPosition = levelCarousel.transform.position;
            Vector3 targetPosition = startPosition + Vector3.left * moveDistance;
            float elapsedTime = 0;

            while (elapsedTime < moveTime)
            {
                levelCarousel.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            levelCarousel.transform.position = targetPosition;
            currentLevel++;
        }
    }
}
