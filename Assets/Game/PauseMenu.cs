using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Camera camera1; // MAIN CAMERA
    public Camera camera2; // MENU CAMERA
    public GameObject pauseObject;
    public GameObject resetObject;
    public GameObject homeObject;

    public GameObject volumeBar;

    public GameObject sceneLight;
    


    private bool isPaused = false;

    private int menuSceneName = 0; //Escena menu numero



    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        volumeBar.SetActive(true);


    }
    

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Detección de clic en el objeto 3D
        if (Input.GetMouseButtonDown(0) && isPaused)
        {
            Ray ray = camera2.ScreenPointToRay(Input.mousePosition); // Usa la cámara1 en lugar de la cámara principal
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
            volumeBar.SetActive(true);
            pauseObject.SetActive(true);
            resetObject.SetActive(true);
            homeObject.SetActive(true);
            sceneLight.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("RESUME");
            camera1.enabled = true;
            camera2.enabled = false;

            volumeBar.SetActive(false);

            pauseObject.SetActive(false);
            resetObject.SetActive(false);
            homeObject.SetActive(false);
            sceneLight.SetActive(true);

        }
       
    }

    public void reset()
    {
        Debug.Log("RESET");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        TogglePause();

       
    }

    public void menu()
    {
        Debug.Log("MENU");
        SceneManager.LoadScene(menuSceneName);
        TogglePause();
    }

}
