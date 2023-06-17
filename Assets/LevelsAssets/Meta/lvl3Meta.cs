using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3Meta : MonoBehaviour
{
    public List<GameObject> objectsToCheck; // La lista de objetos a comprobar

   
    private bool activada = false;
    // Update is called once per frame

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        

        // Comprueba si todos los objetos en la lista han sido destruidos
        foreach (GameObject obj in objectsToCheck)
        {
            if (!obj)
            {
                activarMeta();
                break;
            }
        }

    }
    void activarMeta()
    {
        if (!activada) { 
        this.gameObject.SetActive(true);
        Debug.Log("META DESBLOQUEADA");
            activada = true;
        }
    }
}
