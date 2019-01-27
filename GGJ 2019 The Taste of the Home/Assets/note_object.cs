using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note_object : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyToPress;
    //public musicGameManager m;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    
         
         if(Input.GetKeyDown(KeyToPress)){
            if(canBePressed){
              gameObject.SetActive(false);
              
              musicGameManager.instance.hitted();
            }
        }
    }
    
    private void OnTriggerEnter(Collider other){
        Debug.Log("ss");
        if(other.tag =="button"){
            canBePressed = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.tag =="button"){
            canBePressed = false;
            musicGameManager.instance.missed();
        }
    }
}
