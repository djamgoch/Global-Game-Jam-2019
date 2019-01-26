using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int damage;

    public int speed;


    public float lifetime = 5f;

    [HideInInspector]
    public Vector3 direction = Vector3.up;


    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine("Lifetime");
    }

    public IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }

    public void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Boundry")
            Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
