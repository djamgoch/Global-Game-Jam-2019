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
    public float RotationSpeed = 100f;

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

            float difference = 0.02f;
            transform.localScale = new Vector3( transform.localScale.x - difference, transform.localScale.y - difference, transform.localScale.z - difference);
            float rot = Time.deltaTime * RotationSpeed;
            Debug.Log("Rot is " + rot);
            transform.rotation = Quaternion.Euler(new Vector3(0f,0f, transform.rotation.z - rot));
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
