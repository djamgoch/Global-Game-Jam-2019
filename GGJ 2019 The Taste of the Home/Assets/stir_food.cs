using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stir_food : MonoBehaviour
{   
    private enum cookState
    {
        well_cooked,
        medium_burned,
        very_burned,
    };
    
    private cookState stateIndex; 
    public Text countdown;
    private int Count;
    public countDown t;
    private float cooktime;
    private float elapsedTime;
    public bool getStired;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        cooktime = Mathf.Round(elapsedTime);
        //after five seconeds without stiring, food will show count down 5,4,3...1.
        if ( cooktime == 5f){
            getStired=false;
            //food change color
            t.timer = 10f;
            countdown.gameObject.SetActive(true);
            if(t.timer ==0){
                Debug.Log("burned!");
            }
        }
        
    }
    
    // get stired set cooktime to 0
    private void OnTriggerEnter(Collider collision)
    {   if(collision.tag == "scoop"){
            getStired=true;
            elapsedTime=0f;
            //Debug.Log("TOUCHED");
            t.timer= 0f;
            cooktime  = 0f;
            countdown.gameObject.SetActive(false);
             
            
        }
    
    }
}
