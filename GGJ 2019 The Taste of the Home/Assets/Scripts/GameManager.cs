using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int score = 0;

    public Vector3 PlayerSpawnPosition;

    public GameObject[] EnemySpawns;

    public float SpawnInterval; //how long till the next spawn

    [HideInInspector]
    public float SpawnTime = 0f;

    public GameObject Enemy;

    public Text Score; 
    [HideInInspector]
    public string scoreText = "Score : ";

    public float GameTime; //how long the game lasts
    [HideInInspector]
    public float timeIncrement = 0f;

    public Text Timer;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);

        
    }


    public void ChangeScore(int change) //could be a positive or negaitve change
    {
        Debug.Log("Changing score by " + change);
        instance.score += change;
        ResetScoreText();
       
    }

    public void ResetScoreText()
    {
        instance.Score.text = (instance.scoreText + instance.score);
    }

    void Start()
    {
        ResetScoreText();
        PlayerSpawnPosition = new Vector3(0.31f, -3.75f, 0f);
        EnemySpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        Timer.text = GameTime.ToString();
    }

    void Update()
    {
        StartCoroutine("SpawnEnemies");
        StartCoroutine("GameTimer");
    }

    public IEnumerator GameTimer()
    {
        if(timeIncrement <= Time.time)
        {
            timeIncrement = Time.time + 1f;
            GameTime -= 1;
            Timer.text = GameTime.ToString();
        }
        yield return null;
    }


    public IEnumerator SpawnEnemies()
    {
        if(SpawnTime <= Time.time)
        {
            SpawnTime = Time.time + SpawnInterval;
            GameObject spawn = EnemySpawns[Random.Range(0, EnemySpawns.Length)]; //position 
            Instantiate(Enemy, spawn.transform.position, spawn.transform.rotation);
        }

        yield return null;
    }
}


/*

// Returns the current inputManager
private static AudioManager _audioManager;

public static AudioManager audioManager
{
get {
    if (_audioManager != null)
        return _audioManager;
    _audioManager = FindObjectOfType<AudioManager>();
    if (_audioManager == null)
    {
        Debug.LogWarning("Audio Manager not found, Created new Audio Manager.");
        _audioManager = new GameObject("Audio Manager").AddComponent<AudioManager>();
        GameObject g = GameObject.Find("Managers");
        _audioManager.transform.SetParent(g != null ? g.transform : new GameObject("Managers").transform);
    }
    return _audioManager;
}
}
*/
