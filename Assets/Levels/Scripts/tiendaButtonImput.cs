using UnityEngine;
using UnityEngine.SceneManagement;

public class tiendaButtonImput : MonoBehaviour
{
    public Camera camera2; // MAIN CAMERA
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject salida;


    public Animator animator; // El animator que va a ejecutar el trigger
    private readonly string triggerName = "Rotate"; // El nombre del trigger que quieres ejecutar

    

    void Update()
    {
        // Detección de clic en el objeto 3D
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera2.ScreenPointToRay(Input.mousePosition); // Usa la cámara1 en lugar de la cámara principal
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == c1)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 1");
                }
                if (hit.collider.gameObject == c2)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 2");
                }
                if (hit.collider.gameObject == c3)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 3");
                }
                if (hit.collider.gameObject == c4)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 4");
                }
                if (hit.collider.gameObject == c5)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA EQUIPADO");

                    // Ejecuta el trigger del Animator
                    if (animator != null)
                    {
                        animator.SetTrigger(triggerName);
                    }
                    
                }
                if (hit.collider.gameObject == salida)
                {
                    Debug.Log("SALIDA");

                    SceneManager.LoadScene(0);


                }
            }
        }
    }
}
