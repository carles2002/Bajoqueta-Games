using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonIluminator : MonoBehaviour
{
    public GameObject LightObject; // El objeto que contiene el componente Light

    private Light light; // La luz del objeto

    public float defaultIntensity =0f; // Intensidad de luz por defecto
    public float hoverIntensity = 3f; // Intensidad de luz cuando se hace hover en el botón
    public float clickIntensity = 8f; // Intensidad de luz cuando se hace clic en el botón

    public float fadeSpeed = 0.3f; // Velocidad de cambio de intensidad de luz

    private bool isOver = false;

    void Start()
    {
        // Asegúrate de que el objeto está inicialmente desactivado
        if (LightObject != null)
        {
            LightObject.SetActive(false);

            // Obtiene el componente de luz del objeto
            light = LightObject.GetComponent<Light>();
            if (light != null)
            {
                // Configura la intensidad de la luz al valor por defecto
                light.intensity = defaultIntensity;
            }
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Cuando el ratón está sobre el objeto, activa el objeto
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
                // Cuando el ratón no está sobre el objeto, desactiva el objeto
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
            // Cuando el ratón no está sobre ningún objeto, desactiva el objeto
            if (LightObject != null && isOver)
            {
                isOver = false;
                StopAllCoroutines();
                StartCoroutine(ChangeIntensity(defaultIntensity));
            }
        }

        // Cuando se hace clic en el objeto y el ratón está sobre él, aumenta la intensidad de la luz
        if (Input.GetMouseButtonDown(0) && isOver)
        {
            if (light != null)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeIntensity(clickIntensity));
            }
        }

        // Cuando se libera el clic del mouse, vuelve la intensidad de la luz al valor por defecto
        if (Input.GetMouseButtonUp(0) && isOver)
        {
            if (light != null)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeIntensity(hoverIntensity));
            }
        }
    }

    IEnumerator ChangeIntensity(float targetIntensity)
    {
        while (Mathf.Abs(light.intensity - targetIntensity) > 0.01f)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, fadeSpeed);
            yield return null;
        }
        light.intensity = targetIntensity;
    }
}
