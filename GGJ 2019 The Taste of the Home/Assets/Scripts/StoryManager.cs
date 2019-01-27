using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public GameObject player;

    public Vector3 beginningPosition;
    public Vector3 playerRotation;
    [Tooltip("Position for when player finished all cooking stuff.")]
    public Vector3 endPosition;

    public Canvas[] canvases;
    // Start is called before the first frame update
    void Start()
    {
        switch ((int) GameManager.instance.stateMachine.state) {
            case (int) GameManager.State.Beginning:
                player.transform.position = beginningPosition;
                player.transform.Rotate(playerRotation);
                ActivateCanvas(0);
                break;
            case (int) GameManager.State.TalkedToPersonOnCouch:
                // show UI text for telling player to go cook food
                ActivateCanvas(1);
                break;
            case (int) GameManager.State.CompletedFoodResultCutscene:
                player.transform.position = endPosition;
                player.transform.Rotate(playerRotation);
                // show UI text for telling player to go to sleep
                ActivateCanvas(2);
                break;
            default:
                Debug.Log("used a value out of range.");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AssessProgress();
    }

    void ActivateCanvas(int c) {
        for (int i = 0; i < canvases.Length; i++) {
            if (i == c) 
                canvases[i].gameObject.SetActive(true);
            else
                canvases[i].gameObject.SetActive(false);
        }
    }

    public void SelectActivity(int activity) {
        switch (activity) {
            case 0:
                Debug.Log("Player selected cooking.");
                break;
            case 1:
                Debug.Log("Player selected sleeping.");
                break;
            case 2:
                Debug.Log("Player selecting talking to family member.");
                break;
            default:
                Debug.Log("Error. No correct option selected!");
                break;
        }
    }

    void AssessProgress() {
        switch ((int) GameManager.instance.stateMachine.state) {
            case (int) GameManager.State.Beginning:
                ActivateCanvas(0);
                break;
            case (int) GameManager.State.TalkedToPersonOnCouch:
                // show UI text for telling player to go cook food
                ActivateCanvas(1);
                break;
            case (int) GameManager.State.CompletedFoodResultCutscene:
                // show UI text for telling player to go to sleep
                ActivateCanvas(2);
                break;
            default:
                Debug.Log("used a value out of range.");
                break;
        }
    }
}
