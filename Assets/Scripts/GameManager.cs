using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //ステート
    public enum State
    {
        Ready,
        InGame,
        Result,
        Goal
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
    [SerializeField] private GameObject inGameTimerText;
    [SerializeField] private GameObject gameProgress;
    [SerializeField] private GameObject balloon;
    [SerializeField] private GameObject finish;
    private float currentPosition;
    public float inGameTime = 60;
    private float inGameTimer;

    //Result-----
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject resultProgressText;
    [SerializeField] private GameObject bestProgressText;
    public static float bestProgress;

    //Goal-----
    private float goalTimer = 2;
    [SerializeField] private GameObject goalPanel;
    [SerializeField] private GameObject goalText;
    [SerializeField] private GameObject goalTimeText;
    [SerializeField] private GameObject bestTimeText;
    private static float bestTime = 60;
    private float nowTime;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Ready;
        inGameTimer = inGameTime;
        yoi.SetActive(false);
        start.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Ready:
                readyTimer -= Time.deltaTime;
                ReadyUIActive();
                break;
            case State.InGame:
                inGameTimer -= Time.deltaTime;
                inGameTimerText.GetComponent<Text>().text = String.Format("残り時間" + "{0:00.0}", inGameTimer);
                GameProgress();
                Finish();
                break;
            case State.Result:
                resultPanel.SetActive(true);
                resultProgressText.GetComponent<Text>().text = String.Format("{0:####.0}" + "mすすんだ", currentPosition);
                DisplayBestProgress();
                break;
            case State.Goal:
                goalTimer -= Time.deltaTime;
                inGameTimerText.SetActive(false);
                gameProgress.SetActive(false);
                if (goalTimer < 0)
                {
                    goalText.SetActive(false);
                    goalPanel.SetActive(true);
                    DisplayBestTime();
                    goalTimeText.GetComponent<Text>().text = String.Format("げんざいのきろく\n" + "{0:####.0}" + "びょう", nowTime);
                }
                else
                {
                    goalText.SetActive(true);
                }
                Debug.Log("Goal");
                break;
        }
        
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
    private void GameProgress()
    {
        currentPosition = balloon.transform.position.x;
        gameProgress.GetComponent<Text>().text = String.Format("{0:####.0}" + "m", currentPosition);
    }
    private void Finish()
    {
        if(inGameTimer < 0)
        {
            finish.SetActive(true);
            inGameTimerText.SetActive(false);
            gameProgress.SetActive(false);
            balloon.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if(inGameTimer < -2)
        {
            finish.SetActive(false);
            state = State.Result;
        }
    }

    private void DisplayBestProgress()
    {
        if(bestProgress < currentPosition)
        {
            bestProgress = currentPosition;
        }
        bestProgressText.GetComponent<Text>().text = String.Format("さいこうきろく\n" + "{0:####.0}" + "m", bestProgress);
    }

    private void DisplayBestTime()
    {
        nowTime = inGameTime - inGameTimer;
        if(bestTime > nowTime)
        {
            bestTime = nowTime;
        }
        bestTimeText.GetComponent<Text>().text = String.Format("さいそくきろく\n" + "{0:####.0}" + "びょう", bestTime);
    }

    public void PushTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
