using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitBall : MonoBehaviour {

    private float startClick;
    private float maximumForce = 300;
    

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            //SETS THE START TIME
            startClick = Time.time;
        }

        if (Input.GetMouseButtonUp(0)) {
            //WORKS OUT HOW LONG CLICK WAS HELD DOWN FOR
            float lengthHeldDown = Time.time - startClick;
            //APPLIES LAUNCH FORCE
            Launch(forceOfLaunch(lengthHeldDown));
            //PLAYS SOUNDS
            AudioManager.instance.playClip("weee");
            AudioManager.instance.playClip("Club");
        }
    }

    private float forceOfLaunch(float holdTime) {
        //APPLIES CLAMP TO FORCE, MEANING THAT FORCE INCREASES 0-3 SECONDS BUT NOT BEYOND
        float maxForceHoldDownTime = 3f;
        float force = Mathf.Clamp01(holdTime / maxForceHoldDownTime) * maximumForce;
        //IS MULTIPLIED BY MAXIMUM FORCE AND RETURNED
        return force;
    }

    public void Launch(float force)
    {
        Debug.Log("BALL LAUNCHED");
        //WORKS OUT MOUSE POSITION
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //FINDS ANGLE OF MOUSE POSITION IN RELATION TO OBJECT, THEN REVERSES THIS
        Vector3 dir = (mousePos - transform.position).normalized * -1f;
        //ADDS VELOCITY WITH APPLIED DIRECTION AND FORCE
        transform.GetComponent<Rigidbody2D>().velocity = dir * force;
    }

    //DETECTS IF OBJECT DISAPPEARS OFF SCREEN
    private void OnBecameInvisible()
    {
        StartCoroutine(reloadScene());
    }

    //RELOADS SCENE IN CASE OF FAILURE
    public IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
