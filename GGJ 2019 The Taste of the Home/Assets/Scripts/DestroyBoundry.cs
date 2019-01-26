using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoundry : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other) // when something leaves the game map it dies =(
    {

        if (other.tag == "Player")
        {
            other.gameObject.transform.position = Food1942Manager.instance.PlayerSpawnPosition;  
            
        }
        else
        {
            Destroy(other.gameObject);
        }
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
