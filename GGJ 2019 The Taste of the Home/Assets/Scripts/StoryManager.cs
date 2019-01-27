using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
