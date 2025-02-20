using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//싱글톤

    public GameObject playerSprite;//플레이어 스프라이트 저장

    [SerializeField]//미니게임 목록
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
