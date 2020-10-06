using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private void Start()
    {
        instance = this;
    }
    public IEnumerator loadNextOnTimer(int i)
    {
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
