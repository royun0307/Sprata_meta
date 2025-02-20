using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderBoradNpcController : NpcController
{
    int index = 0;//�ε���
    int score = 0;//�ְ� ����
    public string gameName;//�����̸�
    public string key;//������ �ְ����� ���� Ű

    bool isLeaderBoard = false;//LeaderBoardUI�� On�Ǿ��ִ��� ����

    private void Start()
    {
        SetValue();//�� ����
    }

    protected override void Update()
    {
        base.Update();
        if (isPlayer)//�÷��̾ �������ְ�
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isLeaderBoard)//LeaderBoardUI ���°� �ƴϸ�
                {
                    UIManager.Instance.SetLeaderBoardUI(gameName, score);
                }
                else//LeaderBoardUI���¸�
                {
                    UIManager.Instance.SetHomeUI();
                }
                isLeaderBoard = !isLeaderBoard;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))//�ε��� ����
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
            else if (Input.GetKeyDown(KeyCode.RightArrow))//�ε��� ����
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

        if (!PlayerPrefs.HasKey(key))//����Ȱ��� ������
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt(key);
        }
    }
}
