using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//�̱���

    public GameObject playerSprite;//�÷��̾� ��������Ʈ ����

    [SerializeField]//�̴ϰ��� ���
    public Tuple<string, string>[] game = {
        new Tuple<string, string>("The Stack", "Stack_BestScore"), new Tuple<string, string>("Avoid Skull", "Skull_BestScore")};

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

    }
}
