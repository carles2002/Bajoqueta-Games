using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Camera camera1; // MAIN CAMERA
    public Camera camera2; // MENU CAMERA
    public GameObject pauseObject;
    public GameObject resetObject;
    public GameObject homeObject;

    private bool isPaused = false;

    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Detecci�n de clic en el objeto 3D
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera2.ScreenPointToRay(Input.mousePosition); // Usa la c�mara1 en lugar de la c�mara principal
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == pauseObject)
                {
                    TogglePause();
                }
                if (hit.collider.gameObject == resetObject)
                {
                    reset();
                }
                if (hit.collider.gameObject == homeObject)
                {
                    menu();
                }
            }
        }
    }

    public void TogglePause()
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

        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            Debug.Log("PAUSE");
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("RESUME");
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }

    public void reset()
    {
        Debug.Log("RESET");
    }

    public void menu()
    {
        Debug.Log("MENU");
    }

}
