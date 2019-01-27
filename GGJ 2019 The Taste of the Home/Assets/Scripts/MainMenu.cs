using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public string firstSceneName;

    public string SongToStop;

    public bool shouldIplayasong;

    public string songtoPlay;


    public void StartGame()
    {
        if(SongToStop != "")
            GameManager.instance.audioManager.Stop(SongToStop);
        SceneManager.LoadScene(firstSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        if (shouldIplayasong)
            GameManager.instance.audioManager.Play(songtoPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
