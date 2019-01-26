using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundry : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other) // when something leaves the game map it dies =(
    {
        Debug.Log("Destroying");
        Destroy(other.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
