using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlMover : MonoBehaviour
{
    public GameObject levelCarousel;
    public int currentLevel = 0;
    public float moveDistance = 5.0f; // La distancia que se moverá el carrusel de niveles

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
                    MoveToPreviousLevel();
                }
                else if (hit.transform.name == "FD")
                {
                    // Mover al siguiente nivel
                    MoveToNextLevel();
                }
            }
        }
    }


    void MoveToPreviousLevel()
    {
        // Comprueba si ya estamos en el primer nivel
        if (currentLevel > 0)
        {
            // Mueve el carrusel de niveles hacia la derecha
            levelCarousel.transform.Translate(Vector3.right * moveDistance);

            // Actualiza el nivel actual
            currentLevel--;
        }
    }

    void MoveToNextLevel()
    {
        // Comprueba si ya estamos en el último nivel
        if (currentLevel < levelCarousel.transform.childCount - 1)
        {
            // Mueve el carrusel de niveles hacia la izquierda
            levelCarousel.transform.Translate(Vector3.left * moveDistance);

            // Actualiza el nivel actual
            currentLevel++;
        }
    }
}
