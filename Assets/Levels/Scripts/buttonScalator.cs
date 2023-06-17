using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScalator : MonoBehaviour
{
    public Camera raycastCamera; // La cámara que quieres usar para el raycast
    public GameObject scaleObject; // El objeto que quieres escalar

    public Vector3 defaultScale = Vector3.one; // Escala por defecto
    public Vector3 hoverScale = Vector3.one * 1.5f; // Escala cuando se hace hover en el botón
    public Vector3 clickScale = Vector3.one * 2f; // Escala cuando se hace clic en el botón

    public float scaleSpeed = 0.3f; // Velocidad de cambio de escala

    private bool isOver = false;

    void Start()
    {
        // Asegúrate de que el objeto esté inicialmente a la escala por defecto
        if (scaleObject != null)
        {
            scaleObject.transform.localScale = defaultScale;
        }
    }

    void Update()
    {
        Screen.SetResolution(1920, 1080, true);

        // Comprueba que la cámara esté asignada
        if (raycastCamera == null)
        {
            Debug.LogError("No se ha asignado ninguna cámara para el raycast.");
            return;
        }

        Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Cuando el ratón esté sobre el objeto, escala el objeto hacia arriba
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
                // Cuando el ratón no esté sobre el objeto, escala el objeto hacia abajo
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
            // Cuando el ratón no esté sobre ningún objeto, escala el objeto hacia abajo
            if (scaleObject != null && isOver)
            {
                isOver = false;
                StopAllCoroutines();
                StartCoroutine(ChangeScale(defaultScale));
            }
        }

        // Cuando se hace clic en el objeto y el ratón esté sobre él, aumenta la escala del objeto
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
