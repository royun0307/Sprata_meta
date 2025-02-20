using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSentnace : MonoBehaviour
{
    public string[] sentences;//대화 목록
    public Transform chatPivot; //대화창이 나타날 위치
    public GameObject chatBoxPrefab; //대화창 프리팹

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            ChatSystem chatBox = GetComponentInChildren<ChatSystem>();//대화창 중복 생성 방지
            if (chatBox == null)
            {
                TalkNpc();
            }
        }
    }
    public void TalkNpc()//대화 메서드
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.transform.SetParent(this.transform);
        go.GetComponent<ChatSystem>().OnDialogue(sentences, chatPivot);
    }
}
