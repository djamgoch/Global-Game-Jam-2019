using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundry : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other) // when something leaves the game map it dies =(
    {

        if (other.tag == "enemy")
        {
            Food1942Manager.instance.ChangeScore(-other.gameObject.GetComponent<Enemy>().points);
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
