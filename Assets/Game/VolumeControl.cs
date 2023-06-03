using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;
    public List<Sound> soundScripts;
    public GameObject volumeBar;
    public Scrollbar scrollbar;

    public AudioSource audioSourceMusic; // Para la música de fondo.

    // La clave que usaremos para almacenar y recuperar el valor del volumen en PlayerPrefs.
    private const string VolumeKey = "volume";

    private void Start()
    {
        volumeBar.SetActive(false);
        // Al inicio, recuperamos el valor del volumen de PlayerPrefs y lo ajustamos.
        float storedVolume = PlayerPrefs.GetFloat(VolumeKey, 0.5f); // Usamos 0.5 como valor predeterminado.
        SetLevel(storedVolume);
        scrollbar.value = storedVolume;
    }

    public void OnScrollbarValueChanged(float value)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void SetLevel(float sliderValue)
    {
        float volume = Mathf.Lerp(0f, 0.8f, sliderValue);
        mixer.SetFloat("MusicVol", volume);

        foreach (Sound soundScript in soundScripts)
        {
            if (soundScript != null)
            {
                Debug.Log(volume);
                //soundScript.volumen = Mathf.Pow(10, volume / 20) + 0.2f;
                soundScript.volumen = volume+0.1f;
            }
        }

        if (audioSourceMusic != null)
        {
            audioSourceMusic.volume = volume-0.3f;
        }

        // Guardamos el valor del volumen en PlayerPrefs para que podamos recuperarlo más tarde.
        PlayerPrefs.SetFloat(VolumeKey, sliderValue);
        PlayerPrefs.Save(); // Asegúrate de llamar a Save() para guardar los cambios.
    }
}
