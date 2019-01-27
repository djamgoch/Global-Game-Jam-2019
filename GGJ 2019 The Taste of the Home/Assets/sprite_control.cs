using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_control : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite default_image;
    public Sprite pressed_image;
    
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
       SR= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(key)){
         SR.sprite = pressed_image;
        }
        if(Input.GetKeyUp(key)){
         SR.sprite = default_image;
        }
    }
}
