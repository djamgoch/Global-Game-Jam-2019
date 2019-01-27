using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float timeBlinking = .1f;
    public float timeExpression = .5f;
    // 0 = normal, 1 = blinking, 2 = happy
    // 3 = annoyed, 4 = sad, 5 = hit
    public GameObject[] playerFaces;
    public bool isMoving = false;
    private float timeMoving = 0f;

    private bool idleAnimActive = false;
    private System.Random blinkRNG = new System.Random();
    private int timeTilBlink = 0;

    // Unity Methods
    void Update()
    {
        if (isMoving)
        {
            timeMoving += Time.deltaTime;
            transform.position += new Vector3(0f, Mathf.Cos((timeMoving * 5) % Mathf.PI) * 1f * Time.deltaTime, 0f);
        }
        if (!isMoving)
        {
            if (!idleAnimActive)
            {
                idleAnimActive = true;
                doBlinkAnim();
                timeTilBlink = blinkRNG.Next(1, 11);
                Invoke("setBlinkFlag", (float)timeTilBlink);
            }
        }
    }

    // Private Methods
    private IEnumerator doExpression(int i, float runtime)
    {
        playerFaces[i].SetActive(true);
        playerFaces[0].SetActive(false);
        yield return new WaitForSeconds(runtime);
        playerFaces[0].SetActive(true);
        playerFaces[i].SetActive(false);
    }

    private void setBlinkFlag()
    {
        idleAnimActive = false;
    }

    // Public Methods
    public void setMovingFlag(bool value)
    {
        isMoving = value;
        timeMoving = 0f;
    }
    public void doBlinkAnim()
    {
        StartCoroutine(doExpression(1, timeBlinking));
    }

    public void doHappyAnim()
    {
        StartCoroutine(doExpression(2, timeExpression));
    }

    public void doAnnoyedAnim()
    {
        StartCoroutine(doExpression(3, timeExpression));
    }

    public void doSadAnim()
    {
        StartCoroutine(doExpression(4, timeExpression));
    }

    public void doHitAnim()
    {
        StartCoroutine(doExpression(5, timeExpression));
    }
}
