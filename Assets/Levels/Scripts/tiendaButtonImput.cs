using Newtonsoft.Json;
using QuickType;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
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

    private List<PolySkinElement> PolyDatabase;
    private PolySkin PolyJSON;
    private PolySkinElement polySelected;
    public Animator animator; // El animator que va a ejecutar el trigger
    private readonly string triggerName = "Rotate"; // El nombre del trigger que quieres ejecutar


    public AudioClip clip;
    public AudioClip clip2;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource adjunto al objeto, lo agregamos.
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        
    }

  

    private void Awake()
    {
        Initialize();
    }
    private void OnDestroy()
    {
        PolyJSON.PolyDatabase = PolyDatabase;
        File.WriteAllText("Assets/Player/skins.json", PolyJSON.ToJson()); 
    }

    private void Initialize()
    {
        contador = PlayerPrefs.GetInt("Gems", 0);
        pts.text = contador.ToString();
        //PolyDatabase = JsonConvert.DeserializeObject<Root>().polySkin; 
        PolyJSON = PolySkin.FromJson(File.ReadAllText("Assets/Player/skins.json"));
        PolyDatabase = PolyJSON.PolyDatabase;

        for (int i = 0; i < PolyDatabase.Count; i++)
        {
            polySelected = PolyDatabase[i];
            switch (polySelected.SkinId)
            {
                case 0:
                    c1.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    break;
                case 1:
                    c2.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    break;
                case 2:
                    c3.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    break;
                case 3:
                    c4.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    break;
                default:
                    break;
            }
            if (polySelected.SkinSelected == 1)
            {
                actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinName;
                actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinDescription;
                b5.GetComponent<MeshRenderer>().material = greenMaterial;

                switch (polySelected.SkinId)
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

            }
            if (polySelected.SkinBuy == 1)
            {

                c5.transform.GetChild(0).gameObject.SetActive(true);
                c5.transform.GetChild(1).gameObject.SetActive(false);
                c5.transform.GetChild(2).gameObject.SetActive(false);
               

                switch (polySelected.SkinId)
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

    void Update()
    {
        // Detecci�n de clic en el objeto 3D
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera2.ScreenPointToRay(Input.mousePosition); // Usa la c�mara1 en lugar de la c�mara principal

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == b1)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 1");
                    audioSource.PlayOneShot(clip2);
                    polySelected = PolyDatabase[0];
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinDescription;
                    GameObject actualPrice = actual.transform.GetChild(2).gameObject;
                    actualPrice.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(true);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);

                    if (polySelected.SkinBuy == 1)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.SkinSelected == 1)
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
                }
                if (hit.collider.gameObject == b2)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 2");
                    audioSource.PlayOneShot(clip2);
                    polySelected = PolyDatabase[1];
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinDescription;
                    GameObject actualPrice = actual.transform.GetChild(2).gameObject;
                    actualPrice.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(true);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);

                    if (polySelected.SkinBuy == 1)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.SkinSelected == 1)
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
                }
                if (hit.collider.gameObject == b3)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 3");
                    audioSource.PlayOneShot(clip2);
                    polySelected = PolyDatabase[2];
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinDescription;
                    GameObject actualPrice = actual.transform.GetChild(2).gameObject;
                    actualPrice.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(true);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(false);

                    if (polySelected.SkinBuy == 1)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.SkinSelected == 1)
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
                }
                if (hit.collider.gameObject == b4)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA 4");
                    audioSource.PlayOneShot(clip2);
                    polySelected = PolyDatabase[3];
                    actual.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinName;
                    actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = polySelected.SkinDescription;
                    GameObject actualPrice = actual.transform.GetChild(2).gameObject;
                    actualPrice.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = polySelected.SkinPrice.ToString();
                    polyPrefabs.transform.GetChild(0).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(1).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(2).gameObject.SetActive(false);
                    polyPrefabs.transform.GetChild(3).gameObject.SetActive(true);

                    if (polySelected.SkinBuy == 1)
                    {
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        if (polySelected.SkinSelected == 1)
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
                }
                if (hit.collider.gameObject == b5)
                {
                    Debug.Log("AQUI SE EJECUTA C�DIGO PARA EQUIPADO");
                    audioSource.PlayOneShot(clip2);

                    // Ejecuta el trigger del Animator
                    if (animator != null)
                    {
                        animator.SetTrigger(triggerName);
                    }

                    if (polySelected.SkinBuy == 0)
                    {
                        if (contador >= int.Parse(c5.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text))
                        {
                            contador -= int.Parse(c5.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text); //Usar polySelected.SkinPrice al terminar las pruebas
                            pts.text = contador.ToString();

                            PlayerPrefs.SetInt("Gems", contador);

                            PolyDatabase[(int)polySelected.SkinId].SkinBuy = 1;

                            for (int i = 0; i < PolyDatabase.Count; i++)
                            {
                                if (PolyDatabase[i].SkinSelected == 1)
                                {
                                    PolyDatabase[i].SkinSelected = 0;
                                    switch (PolyDatabase[i].SkinId)
                                    {
                                        case 0:
                                            b1.GetComponent<MeshRenderer>().material = greyMaterial;
                                            break;

                                        case 1:
                                            b2.GetComponent<MeshRenderer>().material = greyMaterial;
                                            break;

                                        case 2:
                                            b3.GetComponent<MeshRenderer>().material = greyMaterial;
                                            break;

                                        case 3:
                                            b4.GetComponent<MeshRenderer>().material = greyMaterial;
                                            break;

                                        default:
                                            break;
                                    }
                                }
                            }
                            PolyDatabase[(int)polySelected.SkinId].SkinSelected = 1;
                            switch (polySelected.SkinId)
                            {
                                case 0:
                                    c1.transform.GetChild(0).gameObject.SetActive(true);
                                    c1.transform.GetChild(1).gameObject.SetActive(false);
                                    c1.transform.GetChild(2).gameObject.SetActive(false);
                                    b1.GetComponent<MeshRenderer>().material = greenMaterial;
                                    break;

                                case 1:
                                    c2.transform.GetChild(0).gameObject.SetActive(true);
                                    c2.transform.GetChild(1).gameObject.SetActive(false);
                                    c2.transform.GetChild(2).gameObject.SetActive(false);
                                    b2.GetComponent<MeshRenderer>().material = greenMaterial;
                                    break;

                                case 2:
                                    c3.transform.GetChild(0).gameObject.SetActive(true);
                                    c3.transform.GetChild(1).gameObject.SetActive(false);
                                    c3.transform.GetChild(2).gameObject.SetActive(false);
                                    b3.GetComponent<MeshRenderer>().material = greenMaterial;
                                    break;

                                case 3:
                                    c4.transform.GetChild(0).gameObject.SetActive(true);
                                    c4.transform.GetChild(1).gameObject.SetActive(false);
                                    c4.transform.GetChild(2).gameObject.SetActive(false);
                                    b4.GetComponent<MeshRenderer>().material = greenMaterial;
                                    break;

                                default:
                                    break;
                            }
                            actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Enhorabuena por tu compra, a disfrutar";
                            c5.transform.GetChild(0).gameObject.SetActive(true);
                            c5.transform.GetChild(1).gameObject.SetActive(false);
                            c5.transform.GetChild(2).gameObject.SetActive(false);
                            audioSource.PlayOneShot(clip);

                        }
                        else
                        {
                            actual.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "No hay suficientes gemas. ";
                        }
                    }
                    else if (polySelected.SkinSelected == 0)
                    {
                        PolyDatabase[(int)polySelected.SkinId].SkinSelected = 1;

                        for (int i = 0; i < PolyDatabase.Count; i++)
                        {
                            if (PolyDatabase[i].SkinSelected == 1)
                            {
                                PolyDatabase[i].SkinSelected = 0;
                                switch (PolyDatabase[i].SkinId)
                                {
                                    case 0:
                                        b1.GetComponent<MeshRenderer>().material = greyMaterial;
                                        break;

                                    case 1:
                                        b2.GetComponent<MeshRenderer>().material = greyMaterial;
                                        break;

                                    case 2:
                                        b3.GetComponent<MeshRenderer>().material = greyMaterial;
                                        break;

                                    case 3:
                                        b4.GetComponent<MeshRenderer>().material = greyMaterial;
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                        PolyDatabase[(int)polySelected.SkinId].SkinSelected = 1;
                        switch (polySelected.SkinId)
                        {
                            case 0:
                                c1.transform.GetChild(0).gameObject.SetActive(true);
                                c1.transform.GetChild(1).gameObject.SetActive(false);
                                c1.transform.GetChild(2).gameObject.SetActive(false);
                                b1.GetComponent<MeshRenderer>().material = greenMaterial;
                                break;

                            case 1:
                                c2.transform.GetChild(0).gameObject.SetActive(true);
                                c2.transform.GetChild(1).gameObject.SetActive(false);
                                c2.transform.GetChild(2).gameObject.SetActive(false);
                                b2.GetComponent<MeshRenderer>().material = greenMaterial;
                                break;

                            case 2:
                                c3.transform.GetChild(0).gameObject.SetActive(true);
                                c3.transform.GetChild(1).gameObject.SetActive(false);
                                c3.transform.GetChild(2).gameObject.SetActive(false);
                                b3.GetComponent<MeshRenderer>().material = greenMaterial;
                                break;

                            case 3:
                                c4.transform.GetChild(0).gameObject.SetActive(true);
                                c4.transform.GetChild(1).gameObject.SetActive(false);
                                c4.transform.GetChild(2).gameObject.SetActive(false);
                                b4.GetComponent<MeshRenderer>().material = greenMaterial;
                                break;

                            default:
                                break;
                        }
                        c5.transform.GetChild(0).gameObject.SetActive(true);
                        c5.transform.GetChild(1).gameObject.SetActive(false);
                        c5.transform.GetChild(2).gameObject.SetActive(false);
                        c5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "EQUIPADO";
                    }
                }
                if (hit.collider.gameObject == salida)
                {
                    Debug.Log("SALIDA");

                    SceneManager.LoadScene(1);


                }
            }
        }
    }
}
