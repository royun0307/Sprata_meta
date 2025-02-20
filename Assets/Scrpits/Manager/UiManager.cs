using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Home,
    LeaderBoard,
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;//싱글톤
    public static UIManager Instance { get { return instance; } }

    UIState currnetState = UIState.Home;
    HomeUI homeUI = null;
    LeaderBoardUI leaderBoardUI = null;

    private void Awake()
    {
        instance = this; 

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);
        leaderBoardUI = GetComponentInChildren<LeaderBoardUI>(true);
        leaderBoardUI?.Init(this);

        ChangeState(UIState.Home);//기본 UI
    }

    public void ChangeState(UIState state)//state변경
    {
        homeUI.SetActive(state);
        leaderBoardUI.SetActive(state);
        currnetState = state;
    }

    public void SetLeaderBoardUI(string gameTitle, int score)//LeaderBoardUI로 설정
    {
        ChangeState(UIState.LeaderBoard);
        leaderBoardUI.SetText(gameTitle, score);
    }

    public void SetHomeUI()//HomeUI로 설정
    {
        ChangeState(UIState.Home);
    }
}
