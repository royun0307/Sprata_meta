using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum Skull_UIState
{
    Home,
    Game,
    Score
}
public class Skull_UIManager : MonoBehaviour
{
    static Skull_UIManager instance; //ΩÃ±€≈Ê
    public static Skull_UIManager Instance { get { return instance; } }

    Skull_UIState currnetState = Skull_UIState.Home;
    Skull_HomeUI homeUI = null;
    Skull_GameUI gameUI = null;
    Skull_ScoreUI scoreUI = null;

    public SkullGenerator skull;

    private void Awake()
    {
        instance = this;
        
        skull = FindObjectOfType<SkullGenerator>();

        homeUI = GetComponentInChildren<Skull_HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<Skull_GameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<Skull_ScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(Skull_UIState.Home);
    }

    public void ChangeState(Skull_UIState state)//state ∫Ø∞Ê
    {
        currnetState = state;
        homeUI?.SetActive(currnetState);
        gameUI?.SetActive(currnetState);
        scoreUI?.SetActive(currnetState);
    }

    public void OnClickStart()
    {
        skull.Restart();
        ChangeState(Skull_UIState.Game);
    }

    public void OnClickExplain(bool isExplain)
    {
        homeUI.explain.gameObject.SetActive(isExplain);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void UpdateLevel()
    {
        gameUI.SetUI(skull.level);
    }

    public void SetLevelUI()
    {
        scoreUI.SetUI(skull.level, skull.bestLevel);
        ChangeState(Skull_UIState.Score);
    }
}
