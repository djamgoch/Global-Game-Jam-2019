using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour
{
    public Text uiText;
    public float mainTimer;
    
    public float timer;
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
            if( Mathf.Round(timer)== 4f){
            uiText.text = "4";}
            if( Mathf.Round(timer)== 5f){
            uiText.text = "5";}
            if( Mathf.Round(timer) == 6f){
            uiText.text ="6";}
            if( Mathf.Round(timer)== 7f){
            uiText.text = "7";}
            if( Mathf.Round(timer)== 8f){
            uiText.text = "8";}
            if( Mathf.Round(timer) == 9f){
            uiText.text ="9";}
            if( Mathf.Round(timer) == 0f){
            uiText.text ="0";}
            
        }
//        else if (timer<=0.0f && !doOnce)
//        {
//            canCount = false;
//            doOnce = true;
//            uiText.text = "0"; //setfalse
//        }
	}
}
