using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    public Text uiText;

    private string originalText;

    private StoryManager storyManager;

    void Awake() {
        storyManager = GameObject.Find("Story Manager").GetComponent<StoryManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originalText = uiText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            uiText.text = originalText + "\nPress Enter";
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            // change UI text to say press Enter
            if (Input.GetKeyDown(KeyCode.Return)) {
                // finish/initiate talking on couch
                if (uiText.gameObject.name.Equals("Couch text")) {
                    storyManager.SelectActivity(2);
                    GameManager.instance.stateMachine.UpdateState();
                }
                // initiate cooking
                else if (uiText.gameObject.name.Equals("Cook text")) {
                    storyManager.SelectActivity(0);
                }
                // initiate sleeping
                else {
                    GameManager.instance.stateMachine.UpdateState();
                }
                
                Debug.Log(GameManager.instance.stateMachine.state);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            uiText.text = originalText;
        }
    }
}
