using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public GameObject player;

    public Vector3 beginningPosition;
    [Tooltip("Position for when player finished all cooking stuff.")]
    public Vector3 EndPosition;
    // Start is called before the first frame update
    void Start()
    {
        switch ((int) GameManager.instance.stateMachine.state) {
            case (int) GameManager.State.Beginning:
                player.transform.position = beginningPosition;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
