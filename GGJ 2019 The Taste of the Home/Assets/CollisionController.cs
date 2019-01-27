using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    public Text uiText;

    private string originalText;
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
                GameManager.instance.stateMachine.UpdateState();
            }
        }
    }

    void OnTriggerLeave(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            uiText.text = originalText;
        }
    }
}
