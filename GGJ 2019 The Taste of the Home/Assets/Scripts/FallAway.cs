using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAway : MonoBehaviour
{


    public float lifetime = 2f;

    public bool left;

    [HideInInspector]
    private float speed = 100f;

    [HideInInspector]
    public bool activated = false;

    [HideInInspector]
    public float lifeeeee = 0f;

    [HideInInspector]
    public float RotationSpeed = 1000f;

    [HideInInspector]
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
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

            movementDirection += (Vector3.down * 2f);

            rb.velocity = (movementDirection * Time.deltaTime * speed);
            //transform.Translate(movementDirection * Time.deltaTime * speed);
            rb.rotation += Time.deltaTime * RotationSpeed;
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
