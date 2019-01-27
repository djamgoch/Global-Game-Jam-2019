using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPlayerController : MonoBehaviour
{
    public float moveSpeed = 30f;

    private Rigidbody rb;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            HubRoomManager.instance.NextScene();
        }
    }


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

        rb.velocity = Vector3.zero;
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            direction += Vector3.forward;
            transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.S)) {
            direction += Vector3.back;
            transform.rotation = Quaternion.Euler(new Vector3(-90f, 180f, 0f));
        }
        if (Input.GetKey(KeyCode.A)) {
            direction += Vector3.left;
            transform.rotation = Quaternion.Euler(new Vector3(-90f, -90f, 0f));
        }
        if (Input.GetKey(KeyCode.D)) {
            direction += Vector3.right;
            transform.rotation = Quaternion.Euler(new Vector3(-90f, 90f, 0f));
        }

        Vector3 movement = direction.normalized * moveSpeed * Time.deltaTime;
        //transform.LookAt(transform.position + movement);
        //transform.rotation = Quaternion.Euler(new Vector3(-90, transform.rotation.y, transform.rotation.z));
        rb.velocity = movement;

        //Debug.Log("Velocity is " + rb.velocity);
    }
}
