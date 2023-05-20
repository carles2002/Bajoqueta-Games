using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonIluminator : MonoBehaviour
{
    public GameObject ChildObject; // El objeto hijo que quieres activar o desactivar

    void Start()
    {
        // Asegúrate de que el objeto hijo está inicialmente desactivado
        if (ChildObject != null)
        {
            ChildObject.SetActive(false);
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Cuando el ratón está sobre el botón, activa el objeto hijo
            if (hit.collider.gameObject == gameObject)
            {
                if (ChildObject != null)
                {
                    ChildObject.SetActive(true);
                }
            }
            else
            {
                // Cuando el ratón no está sobre el botón, desactiva el objeto hijo
                if (ChildObject != null)
                {
                    ChildObject.SetActive(false);
                }
            }
        }
        else
        {
            // Cuando el ratón no está sobre ningún objeto, desactiva el objeto hijo
            if (ChildObject != null)
            {
                ChildObject.SetActive(false);
            }
        }
    }
}
