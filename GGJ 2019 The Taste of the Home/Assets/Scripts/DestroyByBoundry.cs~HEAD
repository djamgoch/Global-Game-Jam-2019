using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundry : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other) // when something leaves the game map it dies =(
    {

        if (other.tag == "Player")
        {
            other.transform.position = GameManager.instance.PlayerSpawnPosition;
            Debug.Log("Now at " + other.transform.position);
        }
        else if(other.tag == "enemy")
        {
            //GameManager.instance.ChangeScore(-other.gameObject.GetComponent<Enemy>().points);
            Destroy(other.gameObject);
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
