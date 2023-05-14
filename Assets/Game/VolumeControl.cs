using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;



    public void OnScrollbarValueChanged(float value)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }


    public void SetLevel(float sliderValue)
    {
        float volume = Mathf.Lerp(-20, 0, sliderValue);
        mixer.SetFloat("MusicVol", volume);
    }

}