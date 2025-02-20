using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    private string minigameName;//미니게임이 있는 씬이름

    public void Awake()
    {
        minigameName = gameObject.name;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(minigameName);//씬이동
        }
    }
}
