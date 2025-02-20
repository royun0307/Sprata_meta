using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSentnace : MonoBehaviour
{
    public string[] sentences;//��ȭ ���
    public Transform chatPivot; //��ȭâ�� ��Ÿ�� ��ġ
    public GameObject chatBoxPrefab; //��ȭâ ������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            ChatSystem chatBox = GetComponentInChildren<ChatSystem>();//��ȭâ �ߺ� ���� ����
            if (chatBox == null)
            {
                TalkNpc();
            }
        }
    }
    public void TalkNpc()//��ȭ �޼���
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.transform.SetParent(this.transform);
        go.GetComponent<ChatSystem>().OnDialogue(sentences, chatPivot);
    }
}
