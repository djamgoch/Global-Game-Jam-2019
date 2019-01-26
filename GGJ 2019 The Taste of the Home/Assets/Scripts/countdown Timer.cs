using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    
    private float timer;
    public bool canCount = true;
    private bool doOnce = false;
    
	// Use this for initialization
	void Start () {
		timer = mainTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer >= 0.0f && canCount)
        {
            timer -=Time.deltaTime;
            
            if( Mathf.Round(timer)== 3f){
            uiText.text = "3";}
            if( Mathf.Round(timer)== 2f){
            uiText.text = "2";}
            if( Mathf.Round(timer) == 1f){
            uiText.text ="1";}
            
        }
        else if (timer<=0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0"; //setfalse
        }
	}
}
