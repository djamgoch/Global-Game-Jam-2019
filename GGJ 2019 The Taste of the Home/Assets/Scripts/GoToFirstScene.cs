using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToFirstScene : MonoBehaviour
{
    public string firstSceneName;
    // Start is called before the first frame update
    void OnClick()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
