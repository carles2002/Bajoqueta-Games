using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonLVL3 : MonoBehaviour
{
    //Variables iniciales
    public GameObject objectToMove; // Referencia al objeto que quieres mover
    public float moveDistanceY = -1f; // La distancia a mover en el eje Y

    public float timer;
    public bool puedeactivar;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.2f;
        i = 0;
        puedeactivar = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                puedeactivar = true;
            }
            else
            {
                puedeactivar = false;
            }
            if (puedeactivar == true)
            {
                if (i <= 1)
                {
                    // Mover el objeto
                    objectToMove.transform.position = new Vector3(
                        objectToMove.transform.position.x,
                        objectToMove.transform.position.y + moveDistanceY,
                        objectToMove.transform.position.z);

                    // Destruir el botón
                    Destroy(this.gameObject);

                    i++;
                    timer = 0.5f;
                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            puedeactivar = false;
        }
    }

}
