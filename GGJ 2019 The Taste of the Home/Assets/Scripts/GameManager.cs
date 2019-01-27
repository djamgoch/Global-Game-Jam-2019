﻿using System.Collections;
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

    [HideInInspector]
    public StateMachine stateMachine { get; private set; }

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
    }

    public void Start()
    {
        stateMachine = new StateMachine();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void UpdateScore(int score)
    {
        TotalScore += score;
        Debug.Log("At the end of the round the score is now " + TotalScore);
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == LastMinigameSceneForCooking) {
            stateMachine.UpdateState(State.CookedFood);
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


