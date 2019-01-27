using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    public int speed;
    public int spinSpeed;

    public float lifetime = 5f;
    private Rigidbody2D RB;

    [HideInInspector]
    public Vector3 direction = Vector3.up;


    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
       // StartCoroutine("Lifetime");
    }

    public IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }

    public void Move()
    {
        RB.velocity = (Vector3.up * Time.deltaTime * speed);
        
            //spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Colliding with + " + collision.name + "  which is " + collision.tag);
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Boundry" && collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "Dead")
            Destroy(this.gameObject);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        RB.rotation += Time.deltaTime * spinSpeed;
    }
}
