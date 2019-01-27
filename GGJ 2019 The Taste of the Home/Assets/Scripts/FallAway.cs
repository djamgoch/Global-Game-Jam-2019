using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAway : MonoBehaviour
{


    public float lifetime = 2f;

    public bool left;

    [HideInInspector]
    public float speed = 1.5f;

    [HideInInspector]
    public bool activated = false;

    [HideInInspector]
    public float lifeeeee = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        //Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {

        if(activated)
        {
            Vector3 movementDirection;
            if (left)
            {
                movementDirection = Vector3.left;
            }
            else
            {
                movementDirection = Vector3.right;
            }

            movementDirection += (Vector3.down * 1.5f);

            transform.Translate(movementDirection * Time.deltaTime * speed);
        }

        
    }

    public void Activate()
    {
        if(!activated)
        {
            //StartCoroutine("Lifetime");
            activated = true;
        }

    }
}
