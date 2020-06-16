using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    #region SingleTon
    public static ScenesLoader Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] float delay;
    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevelCoroutine());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(delay);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    IEnumerator LoadNextLevelCoroutine()
    {
        yield return new WaitForSeconds(delay);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
