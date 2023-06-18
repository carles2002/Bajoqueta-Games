using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicController : MonoBehaviour
{
  public List<int> BNqueSuene = new List<int>(); //Build Niveles que quiero que Suene
  static MusicController instance_Music;
  public static MusicController Instance { get => instance_Music; }
  //---------------------------------------------------------------------------------------------------------------
  private void Update()
  {
    int escena = SceneManager.GetActiveScene().buildIndex;
    if (!BNqueSuene.Contains(escena))
    { DestroyImmediate(gameObject); }
  }
  //---------------------------------------------------------------------------------------------------------------
  private void Awake()
  {
    float volume = PlayerPrefs.GetFloat("volume");
    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
    audioSource.volume = volume;

    if (instance_Music == null)
    {
      instance_Music = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
       DestroyImmediate(gameObject);
    }
  }
}
