using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonLevelSelector : MonoBehaviour
{

    public int level;
    public GameObject otherGameObject; // El otro GameObject
    private SceneManaging otherScript; // El script en el otro GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene la referencia al script en el otro GameObject
        otherScript = otherGameObject.GetComponent<SceneManaging>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    // El raycast ha colisionado con este objeto
                    Debug.Log("Raycast hit this object!");

                    // Llama a la función en el otro script
                    otherScript.ChangeScene(level);
                }
            }
        }
    }
}
