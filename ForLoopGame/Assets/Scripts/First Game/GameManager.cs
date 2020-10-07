using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    //MUST BE PUBLIC AS ACCESSED IN OTHER SCRIPTS
    public List<GameObject> lines;
    //MUST BE PUBLIC AS ACCESSED IN OTHER SCRIPTS
    public bool[] correctAnswers;
    //MUST BE PUBLIC AS ACCESSED IN OTHER SCRIPTS
    public bool[] activated;

    //MUST BE PUBLIC AS ACCESSED IN OTHER SCRIPTS
    public Color targetColor;
    [SerializeField]
    private GameObject transition;
    [SerializeField]
    private GameObject transitionButton;


    private void Awake()
    {
        
    }
    void Start()
    {
        instance = this;
        //SETS ACTIVATED LENGTH
        activated = new bool[correctAnswers.Length];
        //SETS UP TRANSITION SCREEN
        transition.SetActive(true);
        //transitionButton.SetActive(false);
        //SETS PROPERTIES FOR ALL THE LINES
        setRef();
    }

    //SETS LINE PROPERTIES
    public void setRef()
    {
        for(int i = 0; i < correctAnswers.Length; i++)
        {
            LineBehaviour line = lines[i].GetComponent<LineBehaviour>();
            line.uniqueRef = i;
            line.setTarget();
            line.setIndex();
        }
    }

    //CLEARS ACTIVATED OF ANY TRUE BOOLEANS
    public void clearActivatedArray()
    {
        for(int i = 0; i < activated.Length; i++)
        {
            activated[i] = false;
        }
    }

    //CHECKS IF ACTIVATED IS THE SAME AS CORRECT
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

    //RUNS GAME WON ANIMATIONS AND SOUNDS, SETS UP TRANSITION SCREEN
    public IEnumerator gameWon()
    {
        
        yield return new WaitForSeconds(3);
        transitionButton.SetActive(true);
        transition.GetComponent<Animator>().SetTrigger("Slide");
        AudioManager.instance.playClip("cheer");
    }

    //IF WRONG ANSWER, PLAYS SOUND, THEN MOVES VEHICLE (COOKIE) BACK TO ORIGINAL POSITION
    //AND SETS ITS 'MOVE OBJECT' PROPERTY TO FALSE. FLASHES BACKGROUND RED THEN RETURNS IT TO WHITE.
    public IEnumerator wrongAnswer()
    {
        yield return new WaitForSeconds(3);
        AudioManager.instance.playClip("wronganswer");
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
