using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScalator : MonoBehaviour
{
    public Camera raycastCamera; // La c�mara que quieres usar para el raycast
    public GameObject scaleObject; // El objeto que quieres escalar

    public Vector3 defaultScale = Vector3.one; // Escala por defecto
    public Vector3 hoverScale = Vector3.one * 1.5f; // Escala cuando se hace hover en el bot�n
    public Vector3 clickScale = Vector3.one * 2f; // Escala cuando se hace clic en el bot�n

    public float scaleSpeed = 0.3f; // Velocidad de cambio de escala

    private bool isOver = false;

    void Start()
    {
        // Aseg�rate de que el objeto est� inicialmente a la escala por defecto
        if (scaleObject != null)
        {
            scaleObject.transform.localScale = defaultScale;
        }
    }

    void Update()
    {
        Screen.SetResolution(1920, 1080, true);

        // Comprueba que la c�mara est� asignada
        if (raycastCamera == null)
        {
            Debug.LogError("No se ha asignado ninguna c�mara para el raycast.");
            return;
        }

        Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Cuando el rat�n est� sobre el objeto, escala el objeto hacia arriba
            if (hit.collider.gameObject == gameObject)
            {
                if (scaleObject != null && !isOver)
                {
                    isOver = true;
                    StopAllCoroutines();
                    StartCoroutine(ChangeScale(hoverScale));
                }
            }
            else
            {
                // Cuando el rat�n no est� sobre el objeto, escala el objeto hacia abajo
                if (scaleObject != null && isOver)
                {
                    isOver = false;
                    StopAllCoroutines();
                    StartCoroutine(ChangeScale(defaultScale));
                }
            }
        }
        else
        {
            // Cuando el rat�n no est� sobre ning�n objeto, escala el objeto hacia abajo
            if (scaleObject != null && isOver)
            {
                isOver = false;
                StopAllCoroutines();
                StartCoroutine(ChangeScale(defaultScale));
            }
        }

        // Cuando se hace clic en el objeto y el rat�n est� sobre �l, aumenta la escala del objeto
        if (Input.GetMouseButtonDown(0) && isOver)
        {
            if (scaleObject != null)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeScale(clickScale));
            }
        }

        // Cuando se libera el clic del mouse, vuelve la escala del objeto al valor por defecto
        if (Input.GetMouseButtonUp(0) && isOver)
        {
            if (scaleObject != null)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeScale(hoverScale));
            }
        }
    }

    IEnumerator ChangeScale(Vector3 targetScale)
    {
        while (Vector3.Distance(scaleObject.transform.localScale, targetScale) > 0.01f)
        {
            scaleObject.transform.localScale = Vector3.Lerp(scaleObject.transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
            yield return null;
        }
        scaleObject.transform.localScale = targetScale;
    }
}
