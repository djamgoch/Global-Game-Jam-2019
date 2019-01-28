using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public AudioManager audioManager;
    public GameObject AudioManagerPrefab;

    public int TotalScore; 

    public string LastMinigameSceneForCooking = "fry pan";

    public string storyHubSceneName = "Story scene";

    public string firstStoryTextStartLine = "1";
    public string firstStoryTextEndLine = "3";

    public string secondStoryTextStartLine = "5";
    public string secondStoryTextEndLine = "7";

    public string thirdStoryTextStartLine = "9";
    public string thirdStoryTextEndLine = "11"; 

    [HideInInspector] 
    public string currentStoryTextStartLine = "1";
    [HideInInspector]
    public string currentStoryTextEndLine = "3";

    [HideInInspector]
    public StateMachine stateMachine { get; private set; }

    private int storyHubCounter = 0;


    public int HubCount;

    public int SHMUPCount;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);

        if (instance.audioManager == null)
        {
            audioManager = Instantiate(AudioManagerPrefab).GetComponent<AudioManager>();
            audioManager.gameObject.name = "AudioManager"; //I don't like it being named "Clone"
            DontDestroyOnLoad(audioManager);
            //if (scene.name == mainMenuSceneName)
            //    GameManager.instance.audioManager.Play("Main Menu");
        }
        currentStoryTextStartLine = "1";
        currentStoryTextEndLine = "3";

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += onSceneLoaded;
    }

    public void Start()
    {
        stateMachine = new StateMachine();
       // SceneManager.sceneLoaded += OnSceneLoaded;


    }

    void onSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (instance == this)
        {
            string name = scene.name;
            if (name == "HubRoom")
            {
                HubCount = HubCount + 1;
            }
            else if(name == "Title Screen")
            {
                //do fucking nothing
            }
            else
            {
                SHMUPCount = SHMUPCount + 1;
            }
        }
    }



    public string NextSHMUPScene()
    {
        if (HubCount == 1)
        {
            return "First 1944 Minigame";
        }
        else if (HubCount == 2)
        {
            return "Second 1944 Minigame";
        }
        else if(HubCount == 3)
        {
            return "Third 1944 Minigame";
        }
        else
        {
            return "Main Menu";
        }
    }


    public void UpdateScore(int score)
    {
        TotalScore += score;
        Debug.Log("At the end of the round the score is now " + TotalScore);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Mute()
    {
        instance.audioManager.Mute();
    }
    public void SetMasterVolume(float volume)
    {
        instance.audioManager.SetMasterVolume(volume); // calling a function on audiomanager
    }

    public void SetMusicVolume(float volume)
    {
        instance.audioManager.SetMusicVolume(volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        instance.audioManager.SetSoundEffectVolume(volume);
    }

    // public UpdateTextProgress()

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == LastMinigameSceneForCooking) {
            // stateMachine.UpdateState(State.CookedFood);
        }

        if (scene.name == storyHubSceneName) {
            storyHubCounter++;
            if (storyHubCounter <= 1) {
                currentStoryTextStartLine = firstStoryTextStartLine;
                currentStoryTextEndLine = firstStoryTextEndLine;
                stateMachine.UpdateState(State.Beginning);
            }
            else if (storyHubCounter == 2) {
                currentStoryTextStartLine = secondStoryTextStartLine;
                currentStoryTextEndLine = secondStoryTextEndLine;
                stateMachine.UpdateState(State.CookedFood);
            }
            else if (storyHubCounter == 3) {
                currentStoryTextStartLine = thirdStoryTextStartLine;
                currentStoryTextEndLine = thirdStoryTextEndLine;
            }
        }
    }

    public void Update()
    {
        
    }

    public class StateMachine {
        public State state { get; private set; }

        public StateMachine() {
            state = State.Beginning;
        }

        public void UpdateState() {
            if (state == State.Slept) {
                state = State.Beginning;
            }
            else
                state++;
        }

        public void UpdateState(State s) {
            state = s;
        }
    }

    public enum State {
        Beginning=0,
        TalkedToPersonOnCouch,
        CookedFood,
        CompletedFoodResultCutscene,
        Slept,
    }


}


