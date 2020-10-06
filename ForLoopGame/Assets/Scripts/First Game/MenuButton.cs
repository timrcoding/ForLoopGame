using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private bool menuOpen;
    [SerializeField]
    private GameObject menu;

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
        AudioManager.instance.playClip("Crash");
        AudioManager.instance.playClip("Yeah");
        StartCoroutine(LevelLoader.instance.loadNextOnTimer(7));
    }
}
