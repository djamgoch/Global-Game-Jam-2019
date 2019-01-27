using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat_control : MonoBehaviour
{
    public float beatTempo;
    public Transform target;
    public bool begin;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo/60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!begin){
            if(Input.anyKeyDown){
                begin = true;
            }
        }
        if(begin){
            float step =  beatTempo * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            
            //transform.position= new Vector3(transform.position.x,)
        }

    }
}
