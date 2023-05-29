using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tiendaButtonImput : MonoBehaviour
{
    public Camera camera2; // MAIN CAMERA
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject polyPrefabs;
    public GameObject salida;
    public GameObject actual;
    public Material greenMaterial;
    public Material greyMaterial;
    private int contador = 0;
    public Text pts;
    public PolyDatabase PolyDatabase;
    public Poly polySelected;

    public Animator animator; // El animator que va a ejecutar el trigger
    private readonly string triggerName = "Rotate"; // El nombre del trigger que quieres ejecutar

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        contador = PlayerPrefs.GetInt("Gems", 0);
        pts.text = contador.ToString();
        for (int i = 0; i < PolyDatabase.polysCount; i++)
        {
            polySelected = PolyDatabase.GetPoly(i);
            if (polySelected.skinSelected == true)
            {
                actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinName;
                actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinDescription;
                b5.GetComponent<MeshRenderer>().material = greenMaterial;

                switch (polySelected.skinID)
                {
                    case 0:
                        b1.GetComponent<MeshRenderer>().material = greenMaterial;
                        polyPrefabs.transform.GetChild(0).gameObject.SetActive(true);
                        polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);
                        break;
                    case 1:
                        b2.GetComponent<MeshRenderer>().material = greenMaterial;
                        polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(1).gameObject.SetActive(true);
                        polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);
                        break;
                    case 2:
                        b3.GetComponent<MeshRenderer>().material = greenMaterial;
                        polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(2).gameObject.SetActive(true);
                        polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);
                        break;
                    case 3:
                        b4.GetComponent<MeshRenderer>().material = greenMaterial;
                        polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(2).gameObject.SetActive(true);
                        polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);
                        break;
                    default:
                        b2.GetComponent<MeshRenderer>().material = greenMaterial;
                        polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(1).gameObject.SetActive(true);
                        polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                        polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);
                        break;
                }

                if (polySelected.skinBuy == true)
                {

                    c5.transform.GetChild(0).gameObject.SetActive(true);
                    c5.transform.GetChild(1).gameObject.SetActive(false);
                    c5.transform.GetChild(2).gameObject.SetActive(false);


                    switch (polySelected.skinID)
                    {
                        case 0:
                            c1.transform.GetChild(0).gameObject.SetActive(true);
                            c1.transform.GetChild(1).gameObject.SetActive(false);
                            c1.transform.GetChild(2).gameObject.SetActive(false);
                            break;
                        case 1:
                            c2.transform.GetChild(0).gameObject.SetActive(true);
                            c2.transform.GetChild(1).gameObject.SetActive(false);
                            c2.transform.GetChild(2).gameObject.SetActive(false);
                            break;
                        case 2:
                            c3.transform.GetChild(0).gameObject.SetActive(true);
                            c3.transform.GetChild(1).gameObject.SetActive(false);
                            c3.transform.GetChild(2).gameObject.SetActive(false);
                            break;
                        case 3:
                            c4.transform.GetChild(0).gameObject.SetActive(true);
                            c4.transform.GetChild(1).gameObject.SetActive(false);
                            c4.transform.GetChild(2).gameObject.SetActive(false);
                            break;
                        default:
                            c2.transform.GetChild(0).gameObject.SetActive(true);
                            c2.transform.GetChild(1).gameObject.SetActive(false);
                            c2.transform.GetChild(2).gameObject.SetActive(false);
                            break;
                    }
                }
            }
        }

    }

    void Update()
    {
        // Detección de clic en el objeto 3D
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera2.ScreenPointToRay(Input.mousePosition); // Usa la cámara1 en lugar de la cámara principal

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == b1)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 1");
                    polySelected = PolyDatabase.GetPoly(0);
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinDescription;
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(true);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);

                    if (polySelected.skinBuy)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.skinSelected)
                        {
                            b5.GetComponent<MeshRenderer>().material = greenMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "EQUIPADO";
                        }
                        else
                        {
                            b5.GetComponent<MeshRenderer>().material = greyMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Click para equipar";
                        }
                    }
                    else
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(false);
                        c5.transform.GetChild(1).gameObject.SetActive(true);
                        c5.transform.GetChild(2).gameObject.SetActive(true);
                        b5.GetComponent<MeshRenderer>().material = greyMaterial;
                    }



                    /*
                    if (contador > int.Parse(c1.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text))
                    {
                        Debug.Log("Hay monedas suficientes para comprar");
                    }
                    else
                    {
                        Debug.Log("No hay monedas suficientes para comprar");
                    }
                    */
                }
                if (hit.collider.gameObject == b2)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 2");
                    polySelected = PolyDatabase.GetPoly(1);
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinDescription;
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(true);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);

                    if (polySelected.skinBuy)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.skinSelected)
                        {
                            b5.GetComponent<MeshRenderer>().material = greenMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "EQUIPADO";
                        }
                        else
                        {
                            b5.GetComponent<MeshRenderer>().material = greyMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Click para equipar";
                        }
                    }
                    else
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(false);
                        c5.transform.GetChild(1).gameObject.SetActive(true);
                        c5.transform.GetChild(2).gameObject.SetActive(true);
                        b5.GetComponent<MeshRenderer>().material = greyMaterial;
                    }
                    /*
                    if (contador > int.Parse(c2.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text)) 
                    {
                        Debug.Log("Hay monedas suficientes para comprar");
                    }
                    else
                    {
                        Debug.Log("No hay monedas suficientes para comprar");
                    }
                    */
                }
                if (hit.collider.gameObject == b3)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 3");
                    polySelected = PolyDatabase.GetPoly(2);
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinDescription;
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(true);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);

                    if (polySelected.skinBuy)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.skinSelected)
                        {
                            b5.GetComponent<MeshRenderer>().material = greenMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "EQUIPADO";
                        }
                        else 
                        {
                            b5.GetComponent<MeshRenderer>().material = greyMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Click para equipar";
                        }
                    }
                    else
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(false);
                        c5.transform.GetChild(1).gameObject.SetActive(true);
                        c5.transform.GetChild(2).gameObject.SetActive(true);
                        b5.GetComponent<MeshRenderer>().material = greyMaterial;
                    }
                    /*
                    if (contador > int.Parse(c3.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text)) 
                    {
                        Debug.Log("Hay monedas suficientes para comprar");
                    }
                    else
                    {
                        Debug.Log("No hay monedas suficientes para comprar");
                    }
                    */
                }
                if (hit.collider.gameObject == b4)
                {
                    Debug.Log("AQUI SE EJECUTA CÓDIGO PARA 4");
                    polySelected = PolyDatabase.GetPoly(3);
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.skinDescription;
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(true);

                    if (polySelected.skinBuy)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.skinSelected)
                        {
                            b5.GetComponent<MeshRenderer>().material = greenMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "EQUIPADO";
                        }
                        else
                        {
                            b5.GetComponent<MeshRenderer>().material = greyMaterial;
                            c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Click para equipar";
                        }
                    }
                    else
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(false);
                        c5.transform.GetChild(1).gameObject.SetActive(true);
                        c5.transform.GetChild(2).gameObject.SetActive(true);
                        b5.GetComponent<MeshRenderer>().material = greyMaterial;
                    }
                    /*
                    if (contador > int.Parse(c4.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text)) 
                    {
                        Debug.Log("Hay monedas suficientes para comprar");
                    }
                    else
                    {
                        Debug.Log("No hay monedas suficientes para comprar");
                    }
                    */
                }
                if (hit.collider.gameObject == b5)
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
