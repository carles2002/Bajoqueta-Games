using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class VolumeControl : MonoBehaviour
{
    //public AudioMixer mixer;
    public AudioSource coinSource;
    //public List<Sound> soundScripts;
    public GameObject volumeBar;
    public Scrollbar scrollbar;
    public int IndiceEscenaAjustes = 3;
    public int idBar;
    //public float difmusica = 0.2f;

    public AudioSource audioSource; // Para la m�sica de fondo.
    public AudioMixer Mezclador;

    // La clave que usaremos para almacenar y recuperar el valor del volumen en PlayerPrefs.
    private const string VolumeKey = "volume";
    private const string SFXKey = "sfx";

    private void Start()
    {
        int thisScene = SceneManager.GetActiveScene().buildIndex;
        if(thisScene != IndiceEscenaAjustes) {volumeBar.SetActive(false);}
        // Al inicio, recuperamos el valor del volumen de PlayerPrefs y lo ajustamos.
        float storedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        float storedSFX = PlayerPrefs.GetFloat(SFXKey, 1f);
        if (idBar == 0)
        {
            scrollbar.value = storedVolume;
            SetLevel(storedVolume);
        }
        else if (idBar == 1)
        {
            scrollbar.value = storedSFX;
            SetLevel(storedSFX);
        }
    }

    public void OnScrollbarValueChanged(float value)
    {
        if (idBar == 1)
        {
            if (!coinSource.isPlaying)
            {
                coinSource.Play();
            }
        }

    }

    public void SetLevel(float sliderValue)
    {
        float volume = Mathf.Lerp(0f, 1f, sliderValue);
        audioSource.volume = volume;
        if (idBar == 0)
        {
            Mezclador.SetFloat("Musica",sliderValue);
            PlayerPrefs.SetFloat(VolumeKey, sliderValue);
        }
        else if (idBar == 1)
        {
            coinSource.volume = volume;
            Mezclador.SetFloat("SFX",sliderValue);
            PlayerPrefs.SetFloat(SFXKey, sliderValue);
        }
        PlayerPrefs.Save(); // Aseg�rate de llamar a Save() para guardar los cambios.
        //mixer.SetFloat("MusicVol", volume);
        /*
        foreach (Sound soundScript in soundScripts)
        {
            if (soundScript != null)
            {
                Debug.Log(volume);
                //soundScript.volumen = Mathf.Pow(10, volume / 20) + 0.2f;
                //soundScript.volumen = volume+0.1f;
            }
        }
        */




        // Guardamos el valor del volumen en PlayerPrefs para que podamos recuperarlo m�s tarde.
    }
}
