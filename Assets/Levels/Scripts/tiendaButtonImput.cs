using UnityEngine;
using UnityEngine.SceneManagement;

public class tiendaButtonImput : MonoBehaviour
{
    
    public Camera camera2; // MAIN CAMERA
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;


    void Update()
    {

        

        // Detecci�n de clic en el objeto 3D
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera2.ScreenPointToRay(Input.mousePosition); // Usa la c�mara1 en lugar de la c�mara principal
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == c1)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 1");
                }
                if (hit.collider.gameObject == c2)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 2");
                }
                if (hit.collider.gameObject == c3)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 3");
                }
                if (hit.collider.gameObject == c4)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 4");
                }
            }
        }
    }
}
