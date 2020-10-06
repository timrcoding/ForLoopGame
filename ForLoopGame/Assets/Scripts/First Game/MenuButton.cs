using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public bool menuOpen;
    public GameObject menu;

    private void Start()
    {
        menuOpen = true;
        if (menu != null)
        {
            setMenu();
        }
    }

    public void setMenu()
    {
        menuOpen = !menuOpen;
        if (menuOpen)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }

    public void physicsButton()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.GetComponent<Animator>().SetTrigger("Slide");
        GameObject single = GameObject.FindGameObjectWithTag("Singleton");
        Destroy(single);
        GameObject getout = GameObject.FindGameObjectWithTag("GetOut");
        Destroy(getout);
        AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.crash);
        AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.yeah);
        StartCoroutine(LevelLoader.instance.loadNextOnTimer(7));
    }
}
