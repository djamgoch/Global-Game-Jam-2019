using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{


    public Slider bar;

    

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();
    }

    public void UpdateValue(float v)
    {
        bar.value = v;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
