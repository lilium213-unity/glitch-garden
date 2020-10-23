using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float splashTime = 4f;

    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
            StartCoroutine(LoadStartingScreenDelayed());
    }

    private IEnumerator LoadStartingScreenDelayed()
    {
        yield return new WaitForSeconds(splashTime);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
