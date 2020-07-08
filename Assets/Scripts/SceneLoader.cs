using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLastScene()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(sceneCount - 1);
    }
    public void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public int SetLevelIndex()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        return sceneCount;
    }
    private void Awake()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex == 0 && gameManager != null)
        {
            Destroy(gameManager.gameObject);
            
        }
    }
}
