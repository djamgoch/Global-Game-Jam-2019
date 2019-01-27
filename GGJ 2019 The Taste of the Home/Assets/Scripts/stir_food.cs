using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stir_food : MonoBehaviour
{   
    private enum cookState
    {
        raw,
        well_cooked,
        failed,
    };
    
    //change difficulty 
    private enum AgeState
    {
        young,
        medium,
        old,
    };
    
    private SpriteRenderer m_SpriteRenderer;
    private cookState stateIndex; 
    public Text countdown;
    public int Count;
    public countDown t;
    private float cooktime;
    private float elapsedTime;
    public bool getStired;
    private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    
    void Update()
    {
    
        switch ( stateIndex )
            {
                
				case cookState.well_cooked:
                    //newColor.r = Random 
                    m_SpriteRenderer.color = new Color(0.8018868f,0.4971683f,0.2685564f,1f);
                    
                    break;
                    
                case cookState.failed:
                    m_SpriteRenderer.color = new Color(0f,0f,0f,1f);
                    
                    break;
            }
        
        elapsedTime += Time.deltaTime;
        cooktime = Mathf.Round(elapsedTime);
        //after five seconeds without stiring, food will show count down 5,4,3...1.
        if ( cooktime == 5f){
            getStired=false;
            t.timer = 10f;
            countdown.gameObject.SetActive(true);
            
            
            
           
        }
        
        //fail
         if(Mathf.Round(t.timer) <=0f){
                m_SpriteRenderer.color = new Color(0f,0f,0f,1f);
                //stateIndex = cookState.failed;
            }
        //3 round stir 
        if(Count >= 3){
                stateIndex = cookState.well_cooked;
            }
        
    }
    
    // get stired set cooktime to 0
    private void OnTriggerEnter(Collider collision)
    {   if(collision.tag == "scoop"){
            getStired=true;
            elapsedTime=0f;
            t.timer= 10f;
            cooktime  = 0f;
            countdown.gameObject.SetActive(false);
             
             Count +=1;
            //TODO add sound and particle effect
            
        }
    
    }
}
