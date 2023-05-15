using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic; // Necesitarás esta biblioteca para usar List<>.

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;
    public List<Sound> soundScripts; // Lista de referencias a los scripts Sound.

    public void OnScrollbarValueChanged(float value)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void SetLevel(float sliderValue)
    {
        float volume = Mathf.Lerp(-25, -5, sliderValue);
        mixer.SetFloat("MusicVol", volume);

        // Cambia el volumen en todos los scripts Sound.
        foreach (Sound soundScript in soundScripts)
        {
            if (soundScript != null)
            {
                soundScript.volumen = Mathf.Pow(10, volume / 20); // Convertimos el volumen de dB a una escala lineal.
            }
        }
    }
}
