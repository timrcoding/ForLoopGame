using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour
{
    public static AsyncLoad instance;
    private UnityEngine.AsyncOperation async;
    void Start()
    {
        instance = this;
        StartCoroutine(loadAsyncNextLevel());
    }


    IEnumerator loadAsyncNextLevel()
    {
        yield return new WaitForSeconds(0.1f);
        async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        async.allowSceneActivation = false;

        yield return async;

    }

    public void switchChangeLevel()
    {
        async.allowSceneActivation = true;
    }
}
