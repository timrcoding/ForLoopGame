using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForCookie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(check());
    }
    //CHECKS IF COOKIE IS IN SCENE (BUG FIX)
    public IEnumerator check()
    {
        yield return new WaitForSeconds(1);
        GameObject cookie = GameObject.FindGameObjectWithTag("Cookie");
        if(cookie == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("Cookie Loaded");
        }
    }
}
