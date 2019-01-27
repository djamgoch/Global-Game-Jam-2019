using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public int speed;

    public int damageMultiplier;

    public bool DamageBoost;

    public bool MultipleWeapons;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(DamageBoost)
                other.gameObject.GetComponent<Player>().IncreaseDamageMultiplier(damageMultiplier);
            if (MultipleWeapons)
                other.gameObject.GetComponent<Player>().EnableMultipleKnives();

            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
