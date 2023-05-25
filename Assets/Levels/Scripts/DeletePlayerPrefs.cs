using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    public void DeletePlayerPrefabs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs eliminados");
    }
}
