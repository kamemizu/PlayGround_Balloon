using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //ステート
    public enum State
    {
        Ready,
        InGame,
        Result
    }
    public static State state;

    //Ready-----
    //開始エフェクト
    [SerializeField] private GameObject yoi;
    [SerializeField] private GameObject start;
    //ストッパー
    [SerializeField] private GameObject stoper;
    private float readyTimer = 3;

    //InGame-----
    [SerializeField] private Text inGameTimerText;
    [SerializeField] private Text gameProgress;
    [SerializeField] private GameObject balloon;
    [SerializeField] private GameObject finish;
    private float currentPosition;
    private float inGameTimer = 60;

    //Result-----
    private float resultTimer = 2;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject resultProgress;
    [SerializeField] private static GameObject bestScore;
    public static float bestTime;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Ready;
        yoi.SetActive(false);
        start.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Ready:
                ReadyTimer();
                ReadyUIActive();
                break;
            case State.InGame:
                InGameTimer();
                GameProgress();
                Finish();
                break;
            case State.Result:
                resultPanel.SetActive(true);
                resultTimer -= Time.deltaTime;
                resultProgress.GetComponent<Text>().text = String.Format("{0:00.0}" + "mすすんだ", gameProgress);
                break;
        }
        
    }

    private void ReadyTimer()
    {
        readyTimer -= Time.deltaTime;
    }
    private void ReadyUIActive()
    {
        if (readyTimer < 2)
        {
            yoi.SetActive(true);
        }
        if (readyTimer < 0.5)
        {
            yoi.SetActive(false);
            start.SetActive(true);
            stoper.SetActive(false);
        }
        if (readyTimer < 0)
        {
            start.SetActive(false);
            state = State.InGame;
        }
    }

    private void InGameTimer()
    {
        inGameTimer -= Time.deltaTime;
        inGameTimerText.text = String.Format("残り時間" + "{0:00.0}", inGameTimer);
    }
    private void GameProgress()
    {
        currentPosition = balloon.transform.position.x;
        gameProgress.text = String.Format("{0:0}" + "m", currentPosition);
    }
    private void Finish()
    {
        if(inGameTimer < 0)
        {
            finish.SetActive(true);
        }
        if(inGameTimer < -2)
        {
            state = State.Result;
        }
    }
}
