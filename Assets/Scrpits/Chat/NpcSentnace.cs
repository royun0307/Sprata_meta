using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSentnace : MonoBehaviour
{
    public string[] sentences;
    public Transform chatPivot;
    public GameObject chatBoxPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            ChatSystem chatBox = GetComponentInChildren<ChatSystem>();
            if (chatBox == null)
            {
                TalkNpc();
            }
        }
    }
    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.transform.SetParent(this.transform);
        go.GetComponent<ChatSystem>().OnDialogue(sentences, chatPivot);
    }
}
