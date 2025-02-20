using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderBoradNpcController : NpcController
{
    int index = 0;//인덱스
    int score = 0;//최고 점수
    public string gameName;//게임이름
    public string key;//게임의 최고점수 저장 키

    bool isLeaderBoard = false;//LeaderBoardUI가 On되어있는지 여부

    private void Start()
    {
        SetValue();//값 설정
    }

    protected override void Update()
    {
        base.Update();
        if (isPlayer)//플레이어가 접근해있고
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isLeaderBoard)//LeaderBoardUI 상태가 아니면
                {
                    UIManager.Instance.SetLeaderBoardUI(gameName, score);
                }
                else//LeaderBoardUI상태면
                {
                    UIManager.Instance.SetHomeUI();
                }
                isLeaderBoard = !isLeaderBoard;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))//인덱스 감소
            {
                if (index == 0)
                {
                    index = GameManager.Instance.game.Length - 1;
                }
                else
                {
                    index--;
                }
                SetValue();
                UIManager.Instance.SetLeaderBoardUI(gameName, score);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))//인덱스 증가
            {
                index++;
                if(index == GameManager.Instance.game.Length)
                {
                    index = 0;
                }
                SetValue();
                UIManager.Instance.SetLeaderBoardUI(gameName, score);
            }
        }
    }

    private void SetValue()
    {
        gameName = GameManager.Instance.game[index].Item1;
        key = GameManager.Instance.game[index].Item2;

        if (!PlayerPrefs.HasKey(key))//저장된값이 없으면
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt(key);
        }
    }
}
