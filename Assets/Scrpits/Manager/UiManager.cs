using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Home,
    Game,
    Score
}
public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    UIState currnetState = UIState.Home;
    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;

    TheStack theStack = null;

    private void Awake()
    {
        instance = this;

        theStack = FindObjectOfType<TheStack>();

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currnetState = state;
        homeUI?.SetActive(currnetState);
        gameUI?.SetActive(currnetState);
        scoreUI?.SetActive(currnetState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExplain(bool isExplain)
    {
        homeUI.explain.gameObject.SetActive(isExplain);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.Combo);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.BestScore);
        ChangeState(UIState.Score);
    }
}
