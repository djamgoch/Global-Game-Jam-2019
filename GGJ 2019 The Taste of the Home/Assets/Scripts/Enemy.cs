using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int speed;

    public int health;

    public int damage; 

    public int points; //how much the enemy is worth when killed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Food1942Manager.instance.ChangeScore(-points);
            collision.gameObject.GetComponent<Player>().Hurt(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Hurt(collision.gameObject.GetComponent<Weapon>().damage);
        }
    }

    public void Hurt(int damage_taken)
    {
        health -= damage_taken;
    }

    public void CheckDeath()
    {
        if(health <= 0)
        {
            Food1942Manager.instance.ChangeScore(points); //when the enemies die the player score increases
            Destroy(this.gameObject);
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckDeath();
    }
}
