using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubRoomManager : MonoBehaviour
{

    public static HubRoomManager instance;


    string SHMUPSCENE = "1944 Minigame";


    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);


    }


    public void NextScene()
    {
        SceneManager.LoadScene(SHMUPSCENE);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.audioManager.Play("Home");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
