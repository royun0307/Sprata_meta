using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderBoradNpcController : NpcController
{
    int index = 0;
    int score = 0;
    public string gameName;
    public string key;

    bool isPlayer = false;
    bool isLeaderBoard = false;

    private void Start()
    {
        SetValue();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isPlayer = true;
        }
    }

    protected override void Update()
    {
        base.Update();
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isLeaderBoard)
                {
                    UIManager.Instance.SetLeaderBoardUI(gameName, score);
                }
                else
                {
                    UIManager.Instance.SetHomeUI();
                }
                isLeaderBoard = !isLeaderBoard;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
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
            else if (Input.GetKeyDown(KeyCode.RightArrow))
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            UIManager.Instance.SetHomeUI();
            isPlayer = false;
        }
    }

    private void SetValue()
    {
        gameName = GameManager.Instance.game[index].Item1;
        key = GameManager.Instance.game[index].Item2;

        if (!PlayerPrefs.HasKey(key))
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt(key);
        }
    }
}
