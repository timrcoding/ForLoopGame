using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> lines;
    public bool[] correctAnswers;
    public bool[] activated;

    public Color targetColor;
    public GameObject transition;
    public GameObject transitionButton;


    private void Awake()
    {
        
    }
    void Start()
    {
        instance = this;
        activated = new bool[correctAnswers.Length];
        transition.SetActive(true);
        transitionButton.SetActive(false);
        setRef();
    }

    public void setRef()
    {
        for(int i = 0; i < correctAnswers.Length; i++)
        {
            lines[i].GetComponent<LineBehaviour>().uniqueRef = i;
            lines[i].GetComponent<LineBehaviour>().setTarget();
            lines[i].GetComponent<LineBehaviour>().setIndex();
        }
    }

    public void clearActivatedArray()
    {
        for(int i = 0; i < activated.Length; i++)
        {
            activated[i] = false;
        }
    }
    public void checkForCorrectness()
    {
       
        if (correctAnswers.SequenceEqual(activated)){
            StartCoroutine(gameWon());
        }
        else
        {
            StartCoroutine(wrongAnswer());
        }
    }

    public IEnumerator gameWon()
    {
        
        yield return new WaitForSeconds(3);
        transitionButton.SetActive(true);
        transition.GetComponent<Animator>().SetTrigger("Slide");
        AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.cheer);
        LevelCounter.instance.count++;
    }

    public IEnumerator wrongAnswer()
    {
        yield return new WaitForSeconds(3);
        AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.wrongAnswer);
        GameObject[] vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        foreach(GameObject g in vehicles)
        {
            g.GetComponent<VehicleBehaviour>().resetPosition();
            g.GetComponent<VehicleBehaviour>().moveObject = false;
        }
        GameObject background = GameObject.FindGameObjectWithTag("Background");
        background.GetComponent<Image>().color = Color.red;

        yield return new WaitForSeconds(1);
        background.GetComponent<Image>().color = Color.white;
    }
}
