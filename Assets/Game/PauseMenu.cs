using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Camera camera1; // Aquí debes agregar una referencia a la primera cámara
    public Camera camera2; // Aquí debes agregar una referencia a la segunda cámara

    void Start()
    {
        camera1.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (camera1.enabled)
            {
                camera1.enabled = false;
                camera2.enabled = true;
            }
            else
            {
                camera1.enabled = true;
                camera2.enabled = false;
            }
        }
    }
}
