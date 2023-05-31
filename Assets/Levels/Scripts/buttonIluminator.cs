using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonIluminator : MonoBehaviour
{
    public Camera raycastCamera; // La c�mara que quieres usar para el raycast
    public GameObject LightObject; // El objeto que contiene el componente Light

    private Light luz; // La luz del objeto

    public float defaultIntensity = 0f; // Intensidad de luz por defecto
    public float hoverIntensity = 3f; // Intensidad de luz cuando se hace hover en el bot�n
    public float clickIntensity = 8f; // Intensidad de luz cuando se hace clic en el bot�n

    public float fadeSpeed = 0.3f; // Velocidad de cambio de intensidad de luz

    private bool isOver = false;

    void Start()
    {
        // Aseg�rate de que el objeto est� inicialmente desactivado
        if (LightObject != null)
        {
            LightObject.SetActive(false);

            // Obtiene el componente de luz del objeto
            luz = LightObject.GetComponent<Light>();
            if (luz != null)
            {
                // Configura la intensidad de la luz al valor por defecto
                luz.intensity = defaultIntensity;
            }
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
            // Cuando el rat�n est� sobre el objeto, activa el objeto
            if (hit.collider.gameObject == gameObject)
            {
                if (LightObject != null && !isOver)
                {
                    isOver = true;
                    LightObject.SetActive(true);
                    StopAllCoroutines();
                    StartCoroutine(ChangeIntensity(hoverIntensity));
                }
            }
            else
            {
                // Cuando el rat�n no est� sobre el objeto, desactiva el objeto
                if (LightObject != null && isOver)
                {
                    isOver = false;
                    StopAllCoroutines();
                    StartCoroutine(ChangeIntensity(defaultIntensity));
                }
            }
        }
        else
        {
            // Cuando el rat�n no est� sobre ning�n objeto, desactiva el objeto
            if (LightObject != null && isOver)
            {
                isOver = false;
                StopAllCoroutines();
                StartCoroutine(ChangeIntensity(defaultIntensity));
            }
        }

        // Cuando se hace clic en el objeto y el rat�n est� sobre �l, aumenta la intensidad de la luz
        if (Input.GetMouseButtonDown(0) && isOver)
        {
            if (luz != null)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeIntensity(clickIntensity));
            }
        }

        // Cuando se libera el clic del mouse, vuelve la intensidad de la luz al valor por defecto
        if (Input.GetMouseButtonUp(0) && isOver)
        {
            if (luz != null)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeIntensity(hoverIntensity));
            }
        }
    }

    IEnumerator ChangeIntensity(float targetIntensity)
    {
        while (Mathf.Abs(luz.intensity - targetIntensity) > 0.01f)
        {
            luz.intensity = Mathf.Lerp(luz.intensity, targetIntensity, fadeSpeed);
            yield return null;
        }
        luz.intensity = targetIntensity;
    }
}
