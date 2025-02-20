using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    public Queue<string> sentences; //��ȭ ���
    public string currentSentence; //���� ��ȭ
    public TextMeshPro text;
    public GameObject quad; //��ȭ ����

    public void OnDialogue(string[] lines, Transform chatPivot)//��ȭ ���
    {
        transform.position = chatPivot.position;
        sentences = new Queue<string>();
        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }
        StartCoroutine(DialogueFlow(chatPivot));
    }

    IEnumerator DialogueFlow(Transform chatPivot)
    {
        yield return null;

        while (sentences.Count > 0)
        {
            currentSentence = sentences.Dequeue();
            text.text = currentSentence;
            //��ȭâ ũ�� ����
            float x = text.preferredWidth;
            x = (x > 3) ? 3 : x + 0.3f;
            quad.transform.localScale = new Vector2(x, text.preferredHeight + 0.3f);

            transform.position = new Vector2(chatPivot.position.x, chatPivot.position.y + text.preferredHeight / 2);
            yield return new WaitForSeconds(3f);//3�� ���� ���
        }

        Destroy(this.gameObject);//��ȭ�� ������ �ı�
    }
}
