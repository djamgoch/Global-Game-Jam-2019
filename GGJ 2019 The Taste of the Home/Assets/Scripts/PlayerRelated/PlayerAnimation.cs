using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float timeBlinking = .15f;
    public float timeExpression = .2f;
    // 0 = normal, 1 = blinking, 2 = happy
    // 3 = annoyed, 4 = sad, 5 = hit
    public GameObject[] playerFaces;
    private bool goDo = true;

    // Private Methods
    private IEnumerator doExpression(int i, float runtime)
    {
        playerFaces[i].SetActive(true);
        playerFaces[0].SetActive(false);
        yield return new WaitForSeconds(runtime);
        playerFaces[0].SetActive(true);
        playerFaces[i].SetActive(false);
    }

    // Public Methods
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
