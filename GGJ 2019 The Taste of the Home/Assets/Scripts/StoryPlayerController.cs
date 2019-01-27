using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPlayerController : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        try {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        
        catch (System.Exception e) {
            Debug.LogError(gameObject.name + " missing rigidbody compenent!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 direction = Vector3.zero;
        // if (Input.GetKey(KeyCode.W)) {
        //     direction += Vector3.forward;
        // }
        // if (Input.GetKey(KeyCode.S)) {
        //     direction += Vector3.back;
        // }
        // if (Input.GetKey(KeyCode.A)) {
        //     direction += Vector3.left;
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     direction += Vector3.right;
        // }

        // Vector3 movement = direction.normalized * moveSpeed * Time.deltaTime;
        // transform.LookAt(transform.position + movement);
        // rb.velocity = movement;
    }

    void FixedUpdate() {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S)) {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A)) {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) {
            direction += Vector3.right;
        }

        Vector3 movement = direction.normalized * moveSpeed;
        transform.LookAt(transform.position + movement);
        rb.velocity = movement;
    }
}
