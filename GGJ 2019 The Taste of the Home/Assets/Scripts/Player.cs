using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth;
    private Weapon ShotWeapon2;
    private Weapon ShotWeapon3;
    public bool powerup;
    //[HideInInspector]
    public int health;

    [HideInInspector]
    public int speed;

    public int horizontalSpeed;
    public int verticalSpeed;

    private float goHorizontal = 0;
    private float goVertical = 0;

    public int damageMultiplier;

    public float cooldown;

    [HideInInspector]
    public float shootTime = 0.0f;

 //   [HideInInspector]
 //   public Vector3 inputVector = Vector3.zero;

    public GameObject Knife; //this is basically the bullet
    public GameObject Knife2;
    public GameObject Knife3;
    [HideInInspector]
    public GameObject ShootPoint;

    public HealthBar healthBar;


  public void PlayerInput()
    {
 //       inputVector = Vector3.zero;
        goHorizontal = 0;
        goVertical = 0;

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
 //           inputVector += Vector3.up;
            goVertical = 1;
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
 //           inputVector += Vector3.down;
            goVertical = -1;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
 //           inputVector += Vector3.left;
            goHorizontal = -1;
        }
        
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
 //           inputVector += Vector3.right;
            goHorizontal = 1;
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
            GameManager.instance.audioManager.Play("Knife");
            Weapon ShotWeapon = Instantiate(Knife, ShootPoint.transform.position, ShootPoint.transform.rotation).GetComponent<Weapon>();
            if(powerup){
            ShotWeapon2 = Instantiate(Knife2, ShootPoint.transform.position, ShootPoint.transform.rotation).GetComponent<Weapon>();
            ShotWeapon3 = Instantiate(Knife3, ShootPoint.transform.position, ShootPoint.transform.rotation).GetComponent<Weapon>();
            }
            

            ShotWeapon.damage = ShotWeapon.damage * damageMultiplier;
        }
        yield return null;
    }

    public void Move()
    {  
        if(powerup){
            if(ShotWeapon3.transform.position.y>0.04f && ShotWeapon2!=null&& ShotWeapon3!=null)
            {
            ShotWeapon3.transform.position= new Vector3(-ShotWeapon2.transform.position.x,ShotWeapon2.transform.position.y,ShotWeapon2.transform.position.z);
            }
        }
        
        
        transform.Translate(Vector3.up * goVertical * Time.deltaTime * verticalSpeed);
        transform.Translate(Vector3.right * goHorizontal * Time.deltaTime * horizontalSpeed);
    }

    void Start()
    {
        ShootPoint = transform.Find("ShootPoint").gameObject;
        if(!ShootPoint)
        {
            Debug.LogError("Player can't find the shootpoint");
        }
        health = MaxHealth;
        healthBar = FindObjectOfType<HealthBar>();
    }

    public void Hurt(int damage_taken)
    {
        health -= damage_taken;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.UpdateValue((float) (health) / (float)(MaxHealth));
    }

    public void CheckDeath()
    {
        if(health <= 0)
        {
            Debug.Log("Game Over!");
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        PlayerInput();
        Move();
        CheckDeath();
    }
}
