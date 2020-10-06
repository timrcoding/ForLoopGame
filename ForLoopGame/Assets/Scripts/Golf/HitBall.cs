using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitBall : MonoBehaviour {

    public float startClick;
    public float maximumForce;
    

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            //SETS THE START TIME
            startClick = Time.time;
            float holdDownTime = Time.time - startClick;
        }

        if (Input.GetMouseButtonUp(0)) {
            
            float lengthHeldDown = Time.time - startClick;
            Launch(forceOfLaunch(lengthHeldDown));
            AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.weee);
            AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.club);
        }
    }

    private float forceOfLaunch(float holdTime) {
        float maxForceHoldDownTime = 3f;
        float force = Mathf.Clamp01(holdTime / maxForceHoldDownTime) * maximumForce;
        return force;
    }

    public void Launch(float force)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (mousePos - transform.position).normalized * -1f;
        transform.GetComponent<Rigidbody2D>().velocity = dir * force;
    }

    private void OnBecameInvisible()
    {
        StartCoroutine(reloadScene());
    }

    public IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
