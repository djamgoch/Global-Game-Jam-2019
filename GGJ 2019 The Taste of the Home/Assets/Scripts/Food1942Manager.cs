using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food1942Manager : MonoBehaviour
{
    public static Food1942Manager instance;

    public int score = 0;

    public Vector3 PlayerSpawnPosition;

    public GameObject[] EnemySpawns;

    public float SpawnInterval; //how long till the next spawn

    [HideInInspector]
    public float SpawnTime = 0f;


    public GameObject[] Enemies;
    public float[] SpawnPercentages;
    //public GameObject Enemy;

    public Text Score;

    public float GameTime; //how long the game lasts
    [HideInInspector]
    public float timeIncrement = 0f;

    public Text Timer;

    public GameObject WinPanel;
    public Text WinText;
    public Text WinTotalScore;
    public CameraShake camShaker;


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


    public void ChangeScore(int change) //could be a positive or negaitve change
    {
        instance.score += change;
        ResetScoreText();

    }

    public void ResetScoreText()
    {
        instance.Score.text = "Score "+ instance.score;
    }

    void Start()
    {
        ResetScoreText();
        PlayerSpawnPosition = new Vector3(0.31f, -3.75f, 0f);
        EnemySpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        Timer.text = GameTime.ToString();
        GameManager.instance.audioManager.Play("SHMUP");
        WinPanel.SetActive(false);
      
    }

    void FixedUpdate()
    {
        if (GameTime > 0)
        {
            StartCoroutine("SpawnEnemies");
            StartCoroutine("GameTimer");
        }

    }

    public void EnemyDeathCameraShake()
    {
        camShaker.shakeDuration = 0.1f;        
    }

    public IEnumerator GameTimer()
    {
        if (timeIncrement <= Time.time)
        {
            timeIncrement = Time.time + 0.1f;
            GameTime -= 0.1f;
            float DisplayTime = (float)System.Math.Round(GameTime * 100f) / 100f;
            Timer.text = DisplayTime.ToString();
        }

        if (GameTime <= 0)
        {
            GameManager.instance.UpdateScore(score);
            Debug.Log("Game is over! Well this minigame at least");
            WinPanel.SetActive(true);
            WinText.text = "Score : " + score;
            WinTotalScore.text = "Total Score : " + GameManager.instance.TotalScore;

            Enemy[] killEnemy = FindObjectsOfType<Enemy>();

            for(int i = 0; i < killEnemy.Length; i++)
            {
                Destroy(killEnemy[i].gameObject);
            }


            Destroy(FindObjectOfType<Player>().gameObject);

        }
        yield return null;
    }



    public float randomNumber()
    {
        float ran = Random.Range(0f, 1f);
        float sum = 0f;
        //Debug.Log("ran is " + ran);
        for(int i = 0; i < SpawnPercentages.Length;i++)
        {
            float num = SpawnPercentages[i];
            if(ran > sum && ran < (sum + num) )
            {
                //Debug.Log("Found when sum is " + sum + " and num is " + num);
                return i;
            }
            sum += num;
        }

        return -1f;

    }

    public IEnumerator SpawnEnemies()
    {
        if (SpawnTime <= Time.time)
        {
            SpawnTime = Time.time + SpawnInterval;

            int num = (int)(randomNumber());
            GameObject spawn = EnemySpawns[num];
            GameObject enemy = Enemies[num];
           // GameObject spawn = EnemySpawns[Random.Range(0, EnemySpawns.Length)]; //position 
           // GameObject enemy = Enemies[Random.Range(0, Enemies.Length)];
            Instantiate(enemy, spawn.transform.position, spawn.transform.rotation);
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
