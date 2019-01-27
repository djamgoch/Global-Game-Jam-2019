using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicGameManager : MonoBehaviour
{
    public AudioSource Music;
    public bool startplay;
    //public Beat_control B;
    public static musicGameManager instance;
    public GameObject hitImage;
    public GameObject missingImage;
    // Start is called before the first frame update
    void Start()
    {
        instance =this;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(!startplay){
            if(Input.anyKeyDown){
                startplay =true;
                //B.begin= true;
                
                Music.Play();
            }
        }
    }
    
    public void hitted(){
        
        hitImage.SetActive(true);
        Invoke("disappear", 1f);
    }
   
    public void missed(){
        missingImage.SetActive(true);
        //hitImage.SetActive(false);
        Invoke("disappear", 1f);
    }
    
     public void disappear(){
        missingImage.SetActive(false);
        hitImage.SetActive(false);
    }
}
