using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void ChangeScene(int sceneIndex)
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
