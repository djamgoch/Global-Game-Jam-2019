using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public bool right;
    public int speed;
    public int spinSpeed;
    public float		turnRate   = 5f;
    public float		turnRateAcceleration = 18.0f;
    public float       RotateSpeed = 20f;
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
        if(right){
        Vector3	relativePosition =new Vector3(transform.position.x,transform.position.y,0f) - transform.position;
        Quaternion	targetRotation   = Quaternion.LookRotation(relativePosition );
        float	targetRotationAngle =targetRotation.eulerAngles.y;
        float	currentRotationAngle =transform.eulerAngles.y;

        currentRotationAngle = Mathf.LerpAngle(
				currentRotationAngle,
				targetRotationAngle,
				turnRate * Time.deltaTime );

        Quaternion	tiltedRotation = Quaternion.Euler( 0, currentRotationAngle, 0 );	
        turnRate += turnRateAcceleration * Time.deltaTime;	
        transform.rotation = tiltedRotation;	
        transform.Translate ( new Vector3( 0f, 0f , RotateSpeed * Time.deltaTime) );
        }
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
