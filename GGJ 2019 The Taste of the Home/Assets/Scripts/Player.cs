using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health;

    [HideInInspector]
    public int speed;

    public int horizontalSpeed;
    public int verticalSpeed;

    public int damage;

    public float cooldown;

    [HideInInspector]
    public float shootTime = 0.0f;

    [HideInInspector]
    public Vector3 inputVector = Vector3.zero;

    public GameObject Knife; //this is basically the bullet

    [HideInInspector]
    public GameObject ShootPoint;


  public void PlayerInput()
    {
        inputVector = Vector3.zero;

        
        if(Input.GetKey("w") || Input.GetKey("up"))
        {
            inputVector += Vector3.up;
            speed = verticalSpeed;
        }
        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            inputVector += Vector3.left;
            speed = horizontalSpeed;
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            inputVector += Vector3.down;
            speed = verticalSpeed;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            inputVector += Vector3.right;
            speed = horizontalSpeed;
        }

        if (Input.GetKey("space"))
        {
            StartCoroutine("Shoot");
        }

    }

    public IEnumerator Shoot()
    {
        if(shootTime <= Time.time)
        {
            shootTime = Time.time + cooldown;
            Weapon ShotWeapon = Instantiate(Knife, ShootPoint.transform.position, ShootPoint.transform.rotation).GetComponent<Weapon>();
            ShotWeapon.damage = ShotWeapon.damage * damage;
        }
        yield return null;
    }

    public void Move()
    {
        transform.Translate(inputVector * Time.deltaTime * speed);
    }

    void Start()
    {
        ShootPoint = transform.Find("ShootPoint").gameObject;
        if(!ShootPoint)
        {
            Debug.LogError("Player can't find the shootpoint");
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
            Debug.Log("Game Over!");
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        PlayerInput();
        Move();
        CheckDeath();
    }
}
