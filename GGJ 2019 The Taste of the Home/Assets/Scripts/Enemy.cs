using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int speed;

    public int health;

    public int damage; 

    public int points; //how much the enemy is worth when killed

    public bool alive = true;

    [HideInInspector]
    public FallAway Left;
    [HideInInspector]
    public FallAway Right;

    private BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        Left = transform.Find("left").gameObject.GetComponent<FallAway>();
        Right = transform.Find("right").gameObject.GetComponent<FallAway>();
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
        if (collision.gameObject.tag == "Weapon" && alive)
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
            alive = false;
            Left.Activate();
            Right.Activate();
            this.gameObject.tag = "Dead";
            //col.enabled = false;
            GameManager.instance.audioManager.Play("Death");
            Food1942Manager.instance.EnemyDeathCameraShake();
            Destroy(this.gameObject, 0.35f);

            //Destroy(this.gameObject);
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            Move();
            CheckDeath();
        }

    }
}
