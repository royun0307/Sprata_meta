using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum TheStack_UIState
{
    Home,
    Game,
    Score
}
public class TheStack_UIManager : MonoBehaviour
{
    static TheStack_UIManager instance;
    public static TheStack_UIManager Instance { get { return instance; } }

    TheStack_UIState currnetState = TheStack_UIState.Home;
    TheStack_HomeUI homeUI = null;
    TheStack_GameUI gameUI = null;
    TheStack_ScoreUI scoreUI = null;

    TheStack theStack = null;

    private void Awake()
    {
        instance = this;

        theStack = FindObjectOfType<TheStack>();

        homeUI = GetComponentInChildren<TheStack_HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<TheStack_GameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<TheStack_ScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(TheStack_UIState.Home);
    }

    public void ChangeState(TheStack_UIState state)
    {
        currnetState = state;
        homeUI?.SetActive(currnetState);
        gameUI?.SetActive(currnetState);
        scoreUI?.SetActive(currnetState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(TheStack_UIState.Game);
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
        ChangeState(TheStack_UIState.Score);
    }
}
