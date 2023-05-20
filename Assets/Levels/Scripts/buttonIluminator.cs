using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonIluminator : MonoBehaviour
{
    public GameObject ChildObject; // El objeto hijo que quieres activar o desactivar

    void Start()
    {
        // Aseg�rate de que el objeto hijo est� inicialmente desactivado
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
            // Cuando el rat�n est� sobre el bot�n, activa el objeto hijo
            if (hit.collider.gameObject == gameObject)
            {
                if (ChildObject != null)
                {
                    ChildObject.SetActive(true);
                }
            }
            else
            {
                // Cuando el rat�n no est� sobre el bot�n, desactiva el objeto hijo
                if (ChildObject != null)
                {
                    ChildObject.SetActive(false);
                }
            }
        }
        else
        {
            // Cuando el rat�n no est� sobre ning�n objeto, desactiva el objeto hijo
            if (ChildObject != null)
            {
                ChildObject.SetActive(false);
            }
        }
    }
}
