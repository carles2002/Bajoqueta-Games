using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    private const string VolumeKey = "volume";
    private const string SFXKey = "sfx";
    private const float DefaultVolume = 1f;
    public void DeletePlayerPrefabs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs eliminados");

        float volume = PlayerPrefs.GetFloat(VolumeKey);
        float sfx = PlayerPrefs.GetFloat(SFXKey);

        PlayerPrefs.SetFloat(VolumeKey, DefaultVolume);
        PlayerPrefs.SetFloat(SFXKey, DefaultVolume);
    }
}
