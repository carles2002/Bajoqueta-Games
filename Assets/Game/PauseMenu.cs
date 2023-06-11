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
    public GameObject SFXBar;

    public GameObject sceneLight;
    


    private bool isPaused = false;

    private int menuSceneName = 1; //Escena menu numero

    public AudioClip clip;
    private AudioSource audioSource;



    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        volumeBar.SetActive(true);
        SFXBar.SetActive(true);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource adjunto al objeto, lo agregamos.
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
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
                    audioSource.PlayOneShot(clip);
                    TogglePause();
                }
                if (hit.collider.gameObject == resetObject)
                {
                    audioSource.PlayOneShot(clip);
                    reset();
                }
                if (hit.collider.gameObject == homeObject)
                {
                    audioSource.PlayOneShot(clip);
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
            SFXBar.SetActive(true);
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

            SFXBar.SetActive(false);
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
